using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPile : CardPile {

    public bool isFull() {
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

}
