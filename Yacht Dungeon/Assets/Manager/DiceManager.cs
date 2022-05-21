using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    public static DiceManager Inst { get; private set; }
    
    public GameObject[] set1 = new GameObject[5];
    public GameObject[] set2 = new GameObject[5];
    public GameObject[] set3 = new GameObject[5];

    public int[,] diceIndex = new int[3, 5];

    public GameObject[] diceDB_ = new GameObject[30]; // DataBase
    bool[] diceGet = new bool[30];


    void Awake() {
        Inst = this;
    }



    public void StartGame() {
        for (int i = 0; i < diceGet.Length; i++) {
            diceGet[i] = false;
        }
        for (int i = 1; i <= 3; i++) {
            for (int j = 0; j < 5; j++) {
                ChangeDice(i, j);
            }
        }      
    }

    public void Load(Save save) {
        for (int i = 0; i < diceGet.Length; i++) {
            diceGet[i] = false;
        }
        for (int i = 0; i < 5; i++) {
            ChangeDice(1, i, save.set0[i]);
            ChangeDice(2, i, save.set1[i]);
            ChangeDice(3, i, save.set2[i]);
        }        
    }

    public void ChangeDice(int set, int place, int index = 0) {
        switch (set) {
            case 1:
                set1[place] = GameObject.Instantiate(diceDB_[index]);
                break;
            case 2:
                set2[place] = GameObject.Instantiate(diceDB_[index]);
                break;
            case 3:
                set3[place] = GameObject.Instantiate(diceDB_[index]);
                break;
            default:
                Debug.Log("Error");
                break;
        }
        diceGet[index] = true;
        diceIndex[set - 1, place] = index;
    }

    public void RollSet() {
        int set = RoundManager.Inst.currentSet;
        if (set == 0) {
            for (int i = 0; i < 5; i++) {
                set1[i].GetComponent<Dice>().RollDice();
            }
        } else if (set == 1) {
            for (int i = 0; i < 5; i++) {
                set2[i].GetComponent<Dice>().RollDice();
            }
        } else if (set == 2) {
            for (int i = 0; i < 5; i++) {
                set3[i].GetComponent<Dice>().RollDice();
            }
        }
    }

    public int[] GetNumbers() {
        int set = RoundManager.Inst.currentSet;
        int[] ret = new int[5];
        if (set == 1) {
            for (int i = 0; i < 5; i++) {
                ret[i] = set1[i].GetComponent<Dice>().GetNumber();
            }
        } else if (set == 2) {
            for (int i = 0; i < 5; i++) {
                ret[i] = set2[i].GetComponent<Dice>().GetNumber();
            }
        } else if (set == 3) {
            for (int i = 0; i < 5; i++) {
                ret[i] = set3[i].GetComponent<Dice>().GetNumber();
            }
        }
        return ret;
    }

    
}
