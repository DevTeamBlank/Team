using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Inst { get; private set; }

    public int hp = 3;
    public int choice = 1;

    void Awake() {
        Inst = this;
    }

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    
    public void Load(Save save) {
        hp = save.hp;
        choice = save.choice;
    }
}
