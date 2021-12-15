using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    // This Deck is not for battle!

    private int deckSize;
    private List<Card> deck;

    public Vector2 displayStartPosition;
    public float intervalX;
    public float intervalY;

    void Start() {
        deck = new List<Card>();
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
        Vector2 position = displayStartPosition;
        for (int i = 0; i < deckSize; i++) {
            cardList[i].Display(position);
            position += new Vector2(intervalX, 0);
            if (i % 5 == 4) {
                position += new Vector2(0, intervalY);
                position.x = displayStartPosition.x;
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

    /*
    public Deck Copy() {
        Deck newDeck = new();
        newDeck.deckSize = deckSize;
        List<Card> newList = new();
        foreach(Card cards in deck) {
            newList.Add(cards);
        }
        newDeck.displayStartPosition = this.displayStartPosition;
        newDeck.intervalX = this.intervalX;
        newDeck.intervalY = this.intervalY;

        return newDeck;
    }
    */

    public GameObject Copy() {
        return Instantiate(gameObject, transform);
    }
}
