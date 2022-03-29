using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPile : CardPile {

    TurnManager turnManager;

    [SerializeField] GameObject mouseOverCard_ = null; // Mouse Over
    [SerializeField] GameObject holdCard_ = null;

    [SerializeField] bool isHolding = false;

    void Start() {
        turnManager = TurnManager.Inst;
    }

    public bool IsFull() {
        return list_.Count == 10;
    }

    public void Arrange() {
        Order();
        // TODO
    }

    public void Order() {
        for (int i = 0; i < list_.Count; i++) {
            list_[i].GetComponent<Card>().Order(i);
        }
    }

    void UseCard() {
        if (isHolding) {

        }
    }
}
