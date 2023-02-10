using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {
    public static DungeonManager Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

}
