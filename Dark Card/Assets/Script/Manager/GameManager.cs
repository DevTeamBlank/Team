using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

}
