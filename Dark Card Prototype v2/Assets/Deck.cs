using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public static Deck Inst { get; private set; }

    [SerializeField] List<GameObject> cards;

    void Awake() {
        Inst = this;
    }

    void Start() {
        StartingDeck();
    }

    void Update() {

    }

    void StartingDeck() {
        AddCard(0);
        for (int i = 0; i<4; i++) {
            AddCard(1);
        }
        for (int i = 0; i<5; i++) {
            AddCard(2);
        }
    }

    public void AddCard(GameObject card) {
        cards.Add(card);
    }

    public void AddCard(int ID) {
        cards.Add(GameObject.Instantiate(CardDatabase.Inst.GetCard(ID)));
    }

    public void RemoveCard(GameObject card) {
        cards.Remove(card);
    }

    public void RemoveCardIndex(int index) {
        cards.RemoveAt(index);
    }

    public void RemoveCardID(int ID) {
        for (int i = 0; i < cards.Count; i++) {
            if (cards[i].GetComponent<Card>().GetCardID() == ID) {
                RemoveCardIndex(i);
                return;
            }
        }
        Debug.Log("There is no card with this ID.");
    }

    public List<GameObject> CopyDeck() {
        List<GameObject> ret = new List<GameObject>(cards.Count);
        for (int i = 0; i < cards.Count; i++) {
            ret[i] = GameObject.Instantiate(cards[i]);
        }
        return ret;
    }
}
