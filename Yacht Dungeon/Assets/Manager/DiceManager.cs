using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    public static DiceManager Inst { get; private set; }
    
    public GameObject[] set0 = new GameObject[5];
    public GameObject[] set1 = new GameObject[5];
    public GameObject[] set2 = new GameObject[5];

    public GameObject[] diceDB_ = new GameObject[30]; // DataBase

    

    void Awake() {
        Inst = this;
    }



    public void StartGame() {
        for (int i = 0; i < 5; i++) {
            set0[i] = GameObject.Instantiate(diceDB_[0]);
            set1[i] = GameObject.Instantiate(diceDB_[0]);
            set2[i] = GameObject.Instantiate(diceDB_[0]);
        }
    }

    public void Load(Save save) {
        for (int i = 0; i < 5; i++) {
            set0[i] = GameObject.Instantiate(diceDB_[save.set0[i]]);
            set1[i] = GameObject.Instantiate(diceDB_[save.set1[i]]);
            set2[i] = GameObject.Instantiate(diceDB_[save.set2[i]]);
        }
    }

    public void RollSet(int set) {
        if (set == 0) {
            for (int i = 0; i < 5; i++) {
                set0[i].GetComponent<Dice>().RollDice();
            }
        } else if (set == 1) {
            for (int i = 0; i < 5; i++) {
                set1[i].GetComponent<Dice>().RollDice();
            }
        } else if (set == 2) {
            for (int i = 0; i < 5; i++) {
                set2[i].GetComponent<Dice>().RollDice();
            }
        }
    }

    public int[] FinalNumbers(int set) {
        int[] ret = new int[5];
        if (set == 0) {
            for (int i = 0; i < 5; i++) {
                ret[i] = set0[i].GetComponent<Dice>().GetNumber();
            }
        } else if (set == 1) {
            for (int i = 0; i < 5; i++) {
                ret[i] = set1[i].GetComponent<Dice>().GetNumber();
            }
        } else if (set ==2 ) {
            for (int i = 0; i < 5; i++) {
                ret[i] = set2[i].GetComponent<Dice>().GetNumber();
            }
        }
        return ret;
    }

    
}
