using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    // This Deck is not for battle!

    private int deckSize;
    private List<GameObject> deck;
    private int[] IDList;
    
    void Start() {
        DontDestroyOnLoad(gameObject);
        deckSize = 0;
        deck = new List<GameObject>();
    }

    public int GetDeckSize() {
        return deckSize;
    }

    public Vector2 displayStartPosition;
    public float intervalX;
    public float intervalY;

    // On click, Display
    public void Display() {
        GameObject[] cardList = deck.ToArray();
        Vector2 position = displayStartPosition;
        for (int i = 0; i < deckSize; i++) {
            cardList[i].GetComponent<Card>().Display(position);
            position += new Vector2(intervalX, 0);
            if (i % 5 == 4) {
                position += new Vector2(0, intervalY);
                position.x = displayStartPosition.x;
            }
        }
    }

    public void Hide() {
        GameObject[] cardList = deck.ToArray();
        foreach (GameObject card in cardList) {
            card.GetComponent<Card>().HideDisplay();
        }
    }

    public void AddCard(GameObject card) {
        deck.Add(card);
        deckSize++;
    }

    public GameObject Copy() {
        return Instantiate(gameObject, transform);
    }
}
