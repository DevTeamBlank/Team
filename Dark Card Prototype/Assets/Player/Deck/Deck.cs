using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    // This Deck is not for battle!

    private int deckSize;
    private List<Card> deck;

    public Vector2 startPosition;
    public float intervalX;
    public float intervalY;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public int GetDeckSize() {
        return deckSize;
    }

    // On click, Display
    public void Display() {
        Card[] cardList = deck.ToArray();
        Vector2 position = startPosition;
        for (int i = 0; i < deckSize; i++) {
            cardList[i].Display(position);
            position += new Vector2(intervalX, 0);
            if (i % 5 == 4) {
                position += new Vector2(0, intervalY);
                position.x = startPosition.x;
            }
        }
    }

    // 
    public void Hide() {
        Card[] cardList = deck.ToArray();
        foreach (Card card in cardList) {
            card.HideDisplay();
        }
    }

    public void AddCard(Card card) {
        deck.Add(card);
        deckSize++;
    }
}
