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

    public GameObject rerollDot_;
    public GameObject diceKeep_;
    public float popUpOffset_ = 1f;

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        for (int i = 0; i < diceGet.Length; i++) {
            diceGet[i] = false;
        }
        for (int i = 1; i <= 3; i++) {
            for (int j = 1; j <= 5; j++) {
                ChangeDice(i, j);
            }
        }
        Set.Inst.ChangeDiceRollPosition(1);
    }

    GameObject tempGo;

    public void ChangeDice(int set, int place, int index = 0) {
        switch (set) {
            case 1:
                Destroy(set1[place - 1]);
                tempGo = Instantiate(diceDB_[index], Set.Inst.transform);
                tempGo.name = "Dice" + place.ToString();
                set1[place - 1] = tempGo;
                break;
            case 2:
                Destroy(set2[place - 1]);
                tempGo = Instantiate(diceDB_[index], Set.Inst.transform);
                tempGo.name = "Dice" + (place + 5).ToString();
                set2[place - 1] = tempGo;
                break;
            case 3:
                Destroy(set3[place - 1]);
                tempGo = Instantiate(diceDB_[index], Set.Inst.transform);
                tempGo.name = "Dice" + (place + 10).ToString();
                set3[place - 1] = tempGo;
                break;
            default:
                Debug.Log("Error");
                break;
        }
        diceGet[index] = true;
        diceIndex[set - 1, place - 1] = index;
    }

    public void RollSet() {
        int set = RoundManager.Inst.currentSet;
        if (set == 1) {
            for (int i = 0; i < 5; i++) {
                set1[i].GetComponent<Dice>().RollDice();
            }
        } else if (set == 2) {
            for (int i = 0; i < 5; i++) {
                set2[i].GetComponent<Dice>().RollDice();
            }
        } else if (set == 3) {
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


    public List<int> RemainingIndexes() {
        List<int> list = new List<int>();
        for (int i = 1; i < diceDB_.Length; i++) {
            if (!diceGet[i]) list.Add(i);
        }
        return list;
    }

    [SerializeField] GameObject[] rewardDices_ = new GameObject[30]; // This is different from Database, please put prefab here.

    public GameObject RewardDice(int index) {
        return Instantiate(rewardDices_[index]);
    }

    [SerializeField] Vector2 offsetSet;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;

    public int DiceSetPlace(Vector2 screenPosition) {
        Vector2 dicePosition = screenPosition + offsetSet;
        float x1, x12, x23, x34, x45, x5;
        float y1, y12, y23, y3;

        x1 = dicePosition.x;
        x12 = x1 + offsetX;
        x23 = x12 + offsetX;
        x34 = x23 + offsetX;
        x45 = x34 + offsetX;
        x5 = x45 + offsetX;

        y1 = dicePosition.y;
        y12 = y1 - offsetY;
        y23 = y12 - offsetY;
        y3 = y23 - offsetY;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePosition.x;
        float y = mousePosition.y;
        int set = 1, place = 1;

        if (x < x1) {
            return -1;
        } else if (x1 <= x && x < x12) {
            place = 1;
        } else if (x12 <= x && x < x23) {
            place = 2;
        } else if (x23 <= x && x < x34) {
            place = 3;
        } else if (x34 <= x && x < x45) {
            place = 4;
        } else if (x45 <= x && x < x5) {
            place = 5;
        } else { // if (x5 <= x)
            return -1;
        }

        if (y > y1) {
            return -1;
        } else if (y1 >= y && y > y12) {
            set = 1;
        } else if (y12 >= y && y > y23) {
            set = 2;
        } else if (y23 >= y && y > y3) {
            set = 3;
        } else { // if (y3 >= y) {
            return -1;
        }

        if (diceIndex[set - 1, place - 1] == 0) {
            return set * 10 + place; // Please note that this function returns two int with each digits
        } else {
            return -1;
        }
    }

    public void ResetDice() {
        for (int i = 0; i < 5; i++) {
            set1[i].GetComponent<Dice>().SetDice();
            set2[i].GetComponent<Dice>().SetDice();
            set3[i].GetComponent<Dice>().SetDice();
        }
    }

}
