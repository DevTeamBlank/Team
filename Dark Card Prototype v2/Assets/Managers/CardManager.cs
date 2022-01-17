using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public static CardManager Inst { get; private set; }

    bool isDragging;
    GameObject selectedCard;

    List<GameObject> hand = new List<GameObject>(10);
    List<GameObject> drawPile = new List<GameObject>();
    List<GameObject> discardPile = new List<GameObject>();

    public CardPlayStatus cardPlayStatus;

    public enum CardPlayStatus {
        nothing, // Turn Changed
        canMouseOver, // Enemy's turn
        canMouseDrag // My turn
    }

    void Awake() {
        Inst = this;
    }

    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Draw();
        } else if(Input.GetKeyDown(KeyCode.S)) {
            ShuffleDrawPile();
        } else if (Input.GetKeyDown(KeyCode.D)) {
            DiscardAll();
        }
    }

    public void SetCardPlayStatus() {
        if (TurnManager.Inst.isLoading) {
            cardPlayStatus = CardPlayStatus.nothing;
        } else if (!TurnManager.Inst.isMyTurn) {
            cardPlayStatus = CardPlayStatus.canMouseOver;
        } else {
            cardPlayStatus = CardPlayStatus.canMouseDrag;
        }
    }

    public void CardSetting() {
        // TODO
        // Show UI
        cardPlayStatus = CardPlayStatus.nothing;
        CopyDeck();
        ShuffleDrawPile();
    }

    void CopyDeck() {
        drawPile = Deck.Inst.Copy();
    }

    void ShuffleDrawPile() {
        int size = drawPile.Count;
        bool[] selected = new bool[size];
        List<int> indexes = new List<int>(size);
        for (int i = 0; i < size; i++) {
            selected[i] = false;
            indexes[i] = i;
        }

        List<GameObject> list = new List<GameObject>(size);
        for (int i = 0; i < size; i++) {
            int index = Random.Range(0, indexes.Count);
            list[i] = drawPile[index];
            indexes.RemoveAt(i);
        }
        drawPile = list;
    }

    void ShuffleDiscardPileToDrawPile() {
        int size = discardPile.Count;
        for (int i = 0; i < size; i++) {
            drawPile[i] = discardPile[0];
            discardPile.RemoveAt(0);
        }
        ShuffleDrawPile();
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
        hand.Add(card);
        drawPile.RemoveAt(0);
    }

    public void Played(GameObject card) {        
        hand.Remove(card);
        discardPile.Add(card);
    }

    public void DiscardAll() {
        int size = hand.Count;
        for (int i = 0; i < size; i++) {
            discardPile.Add(hand[i]);
            hand.RemoveAt(0);
        }
    }

    public void LevelCleared() {
        // TODO
        // Hide UI
    }
}
