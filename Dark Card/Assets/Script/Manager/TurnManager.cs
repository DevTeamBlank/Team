using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public static TurnManager Inst { get; private set; }

    public enum CardStatus {
        canPlay,
        canMouseOver, // cannot hold
        nothing
    }

    void Awake() {
        Inst = this;
    }

}
