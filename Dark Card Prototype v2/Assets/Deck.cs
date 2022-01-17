using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public static Deck Inst { get; private set; }

    [SerializeField] int size;
    [SerializeField] List<GameObject> cards;

    void Awake() {
        Inst = this;
    }

    void Start() {
        size = cards.Count;
    }
    
    void Update() {

    }

    public void AddCard(GameObject card) {
        cards.Add(card);
        size++;
    }
    
    public void RemoveCard(GameObject card) {
        cards.Remove(card);
        size--;
    }

    public void RemoveCard(int index) {
        cards.RemoveAt(index);
        size--;
    }

    public List<GameObject> Copy() {
        return cards;
    }
}
