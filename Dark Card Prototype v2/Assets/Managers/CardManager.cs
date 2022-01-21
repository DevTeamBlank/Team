using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public static CardManager Inst { get; private set; }

    bool isDragging;
    GameObject selectedCard;

    [SerializeField] List<GameObject> hand = new List<GameObject>(10);
    [SerializeField] List<GameObject> drawPile = new List<GameObject>();
    [SerializeField] List<GameObject> discardPile = new List<GameObject>();
    [SerializeField] List<GameObject> exhaustPile = new List<GameObject>();

    public List<GameObject> GetHand() {
        return hand;
    }

    public CardPlayStatus cardPlayStatus;

    public enum CardPlayStatus {
        cannotPlay,
        canPlay
    }

    void Awake() {
        Inst = this;
    }

    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Draw();
        } else if (Input.GetKeyDown(KeyCode.S)) {
            DiscardAll();
        }

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

    public void SetCardPlayStatus() {
        if (!TurnManager.Inst.isMyTurn) {
            cardPlayStatus = CardPlayStatus.cannotPlay;
        } else {
            cardPlayStatus = CardPlayStatus.canPlay;
        }
    }

    public void CardSetting() {
        // TODO
        // Show UI
        cardPlayStatus = CardPlayStatus.cannotPlay;
        CopyDeck();
        // ShuffleDrawPile();
        HandUpdate();
    }

    void CopyDeck() {
        foreach (GameObject card in Deck.Inst.CopyDeck()) {
            AddDrawPile(card);
        }
    }

    void ShuffleDrawPile() { // TODO. °³²¿ÀÎ ÄÚµå
        int size = drawPile.Count;
        bool[] selected = new bool[size];
        List<int> indexes = new List<int>(size);
        for (int i = 0; i < size; i++) {
            selected[i] = false;
            indexes.Add(i);
        }

        List<GameObject> list = new List<GameObject>(size);
        for (int i = 0; i < size; i++) {
            int index = Random.Range(0, indexes.Count);
            list.Add(drawPile[index]);
            indexes.Remove(index);
        }
        drawPile = list;
    }

    void ShuffleDiscardPileToDrawPile() {
        int size = discardPile.Count;
        for (int i = 0; i < size; i++) {
            AddDrawPile(discardPile[i]);
        }
        discardPile.Clear();
        // ShuffleDrawPile();
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
        hand.Add(card);
        card.transform.parent = GameObject.Find("Hand").transform;
        card.transform.position = card.transform.parent.position;
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
        HandUpdate();
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

    public void DiscardAll() {
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
        Vector2 temp = Camera.main.transform.position;
        float x = temp.x;
        float y = temp.y;
        for (int i = 0; i < hand.Count; i++) {
            float middle = (hand.Count - 1) / 2f;
            float offsetX = intervalX * (i - middle);
            hand[i].transform.position = new Vector2(x + offsetX, y + offsetY);
            hand[i].GetComponent<Card>().Order(i);
        }
    }

    public void LevelCleared() {
        // TODO
        // Hide UI
    }
}
