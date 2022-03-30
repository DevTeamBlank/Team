using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    public static DiceManager Inst { get; private set; }
    
    [SerializeField] GameObject[] set0_ = new GameObject[5];
    [SerializeField] GameObject[] set1_ = new GameObject[5];
    [SerializeField] GameObject[] set2_ = new GameObject[5];

    public GameObject[] diceDB = new GameObject[30]; // DataBase

    void Awake() {
        Inst = this;
    }

    void Start() {
        StartGame();
    }

    public void StartGame() {
        for (int i = 0; i < 5; i++) {
            set0_[i] = GameObject.Instantiate(diceDB[0]);
            set1_[i] = GameObject.Instantiate(diceDB[0]);
            set2_[i] = GameObject.Instantiate(diceDB[0]);
        }
    }

    public void Load(Save save) {
        for (int i = 0; i < 5; i++) {
            set0_[i] = GameObject.Instantiate(diceDB[save.set0[i]]);
            set1_[i] = GameObject.Instantiate(diceDB[save.set1[i]]);
            set2_[i] = GameObject.Instantiate(diceDB[save.set2[i]]);
        }
    }

}
