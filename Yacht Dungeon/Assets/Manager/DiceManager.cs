using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiceManager : MonoBehaviour {

    public static DiceManager Inst { get; private set; }
    
    public GameObject[] set0 = new GameObject[5];
    public GameObject[] set1 = new GameObject[5];
    public GameObject[] set2 = new GameObject[5];

    public GameObject[] diceDB_ = new GameObject[30]; // DataBase

    public enum Made {
        Aces,
        Dueces,
        Threes,
        Fours,
        Fives,
        Sixes,
        Choice,
        FourOfAKind,
        FullHouse,
        SmallStraight,
        LargeStragith,
        Yacht
    }

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
    int AcesScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 1) score += 1;
        }
        return score;
    }

    int DucesScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 2) score += 2;
        }
        return score;
    }
    int ThreesScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 3) score += 3;
        }
        return score;
    }
    int FoursScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 4) score += 4;
        }
        return score;
    }
    int FivesScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 5) score += 5;
        }
        return score;
    }
    int SixesScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 6) score += 6;
        }
        return score;
    }

    int ChoiceScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            score += num[i];
        }
        return score;
    }

    int FourOfAKindScore(int[] num) {
        int score = 0;
        int[] c = new int[5];
        for (int i = 0; i < 5; i++) {
            c[i] = num[i];
        }
        Array.Sort(c);
        if (c[1] == c[2] && c[2] == c[3] && (c[0] == c[1] || c[3] == c[4])) {
            for (int i = 0; i < 5; i++) {
                score += num[i];
            }
        } else {
            return 0;
        }
        return score;
    }

    int FullHouseScore(int[] num) {
        int score = 0;
        int[] c = new int[5];
        for (int i = 0; i < 5; i++) {
            c[i] = num[i];
        }
        Array.Sort(c);
        if (c[0] == c[1] && c[3] == c[4] && (c[1] == c[2] || c[2] == c[3])) {
            for (int i = 0; i < 5; i++) {
                score += num[i];
            }
        } else {
            return 0;
        }
        return score;
    }

    int SmallStraightScore(int[] num) {
        int[] c = new int[5];
        for (int i = 0; i < 5; i++) {
            c[i] = num[i];
        }
        Array.Sort(c);
        if (c[1] + 1 == c[2] && c[2] + 1 == c[3] && (c[0] + 1 == c[1] || c[3] + 1 == c[4])) {
            return 15;
        } else {
            return 0;
        }
    }
    int LargeStraightScore(int[] num) {
        int[] c = new int[5];
        for (int i = 0; i < 5; i++) {
            c[i] = num[i];
        }
        Array.Sort(c);
        if (c[0] + 1 == c[1] && c[1] + 1 == c[2] && c[2] + 1 == c[3] && c[3] + 1 == c[4]) {
            return 30;
        } else {
            return 0;
        }
    }

    int YachtScore(int[] num) {
        if (num[0] == num[1] && num[1] == num[2] && num[2] == num[3] && num[3] == num[4]) {
            return 50;
        } else {
            return 0;
        }
    }
}
