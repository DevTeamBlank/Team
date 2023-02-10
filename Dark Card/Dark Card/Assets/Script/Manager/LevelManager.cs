using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

}
