using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public static CardManager Inst { get; private set; }

    [SerializeField] List<GameObject> hand = new List<GameObject>(10);
    [SerializeField] List<GameObject> drawPile = new List<GameObject>();
    [SerializeField] List<GameObject> discardPile = new List<GameObject>();
    [SerializeField] List<GameObject> exhaustPile = new List<GameObject>();

    public List<GameObject> GetHand() {
        return hand;
    }
    public List<GameObject> GetDrawPile() {
        return drawPile;
    }
    public List<GameObject> GetDiscardPile() {
        return discardPile;
    }
    public List<GameObject> GetExhaustPile() {
        return exhaustPile;
    }

    public CardPlayStatus cardPlayStatus;

    public enum CardPlayStatus {
        cannotPlay,
        canPlay,
        notInBattle
    }

    void Awake() {
        Inst = this;
    }

    void Start() {

    }

    void Update() {
        if (cardPlayStatus != CardPlayStatus.notInBattle && Input.GetKeyDown(KeyCode.A)) {
            Draw();
        }

        if (cardPlayStatus == CardPlayStatus.canPlay) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Play(0);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                Play(1);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                Play(2);
            } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                Play(3);
            } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                Play(4);
            } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                Play(5);
            } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
                Play(6);
            } else if (Input.GetKeyDown(KeyCode.Alpha8)) {
                Play(7);
            } else if (Input.GetKeyDown(KeyCode.Alpha9)) {
                Play(8);
            } else if (Input.GetKeyDown(KeyCode.Alpha0)) {
                Play(9);
            }
        }        
    }

    public void SetCardPlayStatus() {
        if (!TurnManager.Inst.isMyTurn) {
            cardPlayStatus = CardPlayStatus.cannotPlay;
        } else {
            cardPlayStatus = CardPlayStatus.canPlay;
        }
    }

    public void CardSetting() {
        ResetAll();
        cardPlayStatus = CardPlayStatus.cannotPlay;
        CopyDeckToDrawPile();
        ShuffleDrawPile();
        HandUpdate();
    }

    void ResetAll() {
        Transform handTransform = GameObject.Find("Hand").transform;
        for (int i = 0; i < handTransform.childCount; i++) {
            Destroy(handTransform.GetChild(i).gameObject);
        }
        hand.Clear();
        Transform drawPileTransform = GameObject.Find("DrawPile").transform;
        for (int i = 0; i < drawPileTransform.childCount; i++) {
            Destroy(drawPileTransform.GetChild(i).gameObject);
        }
        drawPile.Clear();
        Transform discardPileTransform = GameObject.Find("DiscardPile").transform;
        for (int i = 0; i < discardPileTransform.childCount; i++) {
            Destroy(discardPileTransform.GetChild(i).gameObject);
        }
        discardPile.Clear();
        Transform exhaustPileTransform = GameObject.Find("ExhaustPile").transform;
        for (int i = 0; i < exhaustPileTransform.childCount; i++) {
            Destroy(exhaustPileTransform.GetChild(i).gameObject);
        }
        exhaustPile.Clear();
        HandUpdate();
    }

    void CopyDeckToDrawPile() {
        foreach (GameObject card in Deck.Inst.CopyDeck()) {
            AddDrawPile(card);
        }
    }

    public void ShuffleDrawPile() {
        for (int i = drawPile.Count - 1; i > 0; i--) {
            int random = Random.Range(0, i); ;
            GameObject temp = drawPile[i];
            drawPile[i] = drawPile[random];
            drawPile[random] = temp;
        }
    }

    public void ShuffleDiscardPileToDrawPile() {
        int size = discardPile.Count;
        for (int i = 0; i < size; i++) {
            AddDrawPile(discardPile[i]);
        }
        discardPile.Clear();
        ShuffleDrawPile();
    }

    public void AddDiscardPile(GameObject card) {
        discardPile.Add(card);
        card.transform.parent = GameObject.Find("DiscardPile").transform;
        card.transform.position = card.transform.parent.position;
    }

    public void AddDrawPile(GameObject card) {
        drawPile.Add(card);
        card.transform.parent = GameObject.Find("DrawPile").transform;
        card.transform.position = card.transform.parent.position;
    }

    public void AddHand(GameObject card) {
        if (hand.Count < 10) {
            hand.Add(card);
            card.transform.parent = GameObject.Find("Hand").transform;
            card.transform.position = card.transform.parent.position;
            HandUpdate();
        } else { // Hand is full.
            AddDiscardPile(card);
        }
    }

    public void AddExhaustPile(GameObject card) {
        exhaustPile.Add(card);
        card.transform.parent = GameObject.Find("ExhaustPile").transform;
        card.transform.position = card.transform.parent.position;
    }

    public void DrawCards(int num) {
        for (int i = 0; i < num; i++) {
            Draw();
        }
    }

    void Draw() {
        if (hand.Count == 10) {
            Debug.Log("Hand is full.");
            return;
        }

        if (drawPile.Count == 0) {
            ShuffleDiscardPileToDrawPile();
            if (drawPile.Count == 0) {
                Debug.Log("DrawPile and DiscardPile are both empty.");
                return;
            }
        }

        GameObject card = drawPile[0];
        AddHand(card);
        drawPile.RemoveAt(0);
        card.GetComponent<Card>().Drawn();
    }

    public void Play(int index) {
        if (index < 0 || hand.Count <= index) {
            Debug.Log("Unvalid index.");
            return;
        }
        hand[index].GetComponent<Card>().Play();
    }

    public void Played(GameObject card) {
        hand.Remove(card);
        HandUpdate();
        if (card.GetComponent<Card>().GetIsExhaust()) {
            AddExhaustPile(card);
        } else {
            AddDiscardPile(card);
        }
    }

    public void TurnEnd() {
        int size = hand.Count;
        for (int i = 0; i < size; i++) {
            hand[i].GetComponent<Card>().TurnEnd();
            if (hand[i].GetComponent<Card>().GetIsEthereal()) {
                AddExhaustPile(hand[i]);
            } else {
                AddDiscardPile(hand[i]);
            }
        }

        hand.Clear();
        HandUpdate();
    }

    void DiscardAll() {
        int size = hand.Count;
        for (int i = 0; i < size; i++) {
            AddDiscardPile(hand[i]);
        }
        hand.Clear();
        HandUpdate();
    }

    [SerializeField] float intervalX;
    [SerializeField] float offsetY;

    public void HandUpdate() {
        if (hand.Count == 0) {
            return;
        }
        for (int i = 0; i < hand.Count; i++) {
            float middle = (hand.Count - 1) / 2f;
            float offsetX = intervalX * (i - middle);
            hand[i].transform.position = hand[i].transform.parent.position;
            hand[i].transform.Translate(new Vector3(offsetX, 0, 0));
            hand[i].GetComponent<Card>().Order(i);
        }
    }

    public void LevelCleared() {
        cardPlayStatus = CardPlayStatus.notInBattle;
    }
}
