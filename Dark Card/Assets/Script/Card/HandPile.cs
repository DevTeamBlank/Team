using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPile : CardPile {

    public bool isFull() {
        return list_.Count == 10;
    }

    public void Arrange() {
        // TODO
    }

}
