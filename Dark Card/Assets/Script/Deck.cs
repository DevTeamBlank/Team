using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public static Deck Inst { get; private set; }

    [SerializeField] List<GameObject> list_;
    [SerializeField] List<GameObject> startingDeck;

    void Awake() {
        Inst = this;
    }

    public void AddCard(GameObject card) {
        GameObject temp = Instantiate(card, transform);
        temp.name = card.GetComponent<Card>().nomenclature;
        list_.Add(temp);
    }

    public void RemoveCard(int ID, int qty = 1) {
        for (int i = 0; i < qty; i++) {
            GameObject temp = null;
            for (int j = 0; j < list_.Count; j++) {
                if (Card.ID(list_[j]) == ID) {
                    temp = list_[j];
                    break;
                }
            }
            if (temp != null) list_.Remove(temp);
        }
    }

    public List<GameObject> CopyDeck() {
        List<GameObject> list = new List<GameObject>(list_.Count);
        for (int i = 0; i < list_.Count; i++) {
            GameObject temp = Instantiate(list_[i], transform);
            temp.transform.position = transform.position;
            list.Add(temp);
        }
        return list;
    }

}
