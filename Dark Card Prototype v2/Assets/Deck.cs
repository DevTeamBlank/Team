using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public static Deck Inst { get; private set; }

    [SerializeField] List<GameObject> cards;

    [SerializeField] List<GameObject> startingDeck;

    void Awake() {
        Inst = this;
        DeckSetting();
    }

    void Start() {
        
    }

    void Update() {

    }

    void StartingDeck() {
        for (int i = 0; i < startingDeck.Count; i++) {
            AddCard(startingDeck[i]);
        }
    }

    public void DeckSetting() {
        StartingDeck();
    }

    public void AddCard(GameObject card) {
        GameObject temp = GameObject.Instantiate(card, transform);
        temp.name = card.GetComponent<Card>().nomenclature;
        cards.Add(temp);
    }

    public void AddCard(int ID) {
        GameObject temp = GameObject.Instantiate(CardDatabase.Inst.GetCard(ID), transform);
        temp.name = CardDatabase.Inst.GetCard(ID).GetComponent<Card>().nomenclature;
        cards.Add(temp);
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
            GameObject temp = GameObject.Instantiate(cards[i]);
            temp.transform.parent = transform;
            temp.transform.position = transform.position;
            ret.Add(temp);
            
        }
        return ret;
    }
}
