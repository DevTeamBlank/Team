using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MadeTable : MonoBehaviour {

    public static MadeTable Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    [SerializeField] Vector2 pos_;
    Vector2 originPos;

    TextMeshPro aces;
    TextMeshPro duces;
    TextMeshPro threes;
    TextMeshPro fours;
    TextMeshPro fives;
    TextMeshPro sixes;
    TextMeshPro choice;
    TextMeshPro fourOfAKind;
    TextMeshPro fullHouse;
    TextMeshPro smallStraight;
    TextMeshPro largeStraight;
    TextMeshPro yacht;

    [SerializeField] int currentSet;
    [SerializeField] Made set0Made;
    [SerializeField] Made set1Made;
    [SerializeField] Made set2Made;

    private void Start() {
        originPos = transform.position;
        FindText();
        ResetTable();
    }

    void FindText() {
        aces = transform.Find("Aces").GetComponent<TextMeshPro>();
        duces = transform.Find("Duces").GetComponent<TextMeshPro>();
        threes = transform.Find("Threes").GetComponent<TextMeshPro>();
        fours = transform.Find("Fours").GetComponent<TextMeshPro>();
        fives = transform.Find("Fives").GetComponent<TextMeshPro>();
        sixes = transform.Find("Sixes").GetComponent<TextMeshPro>();
        choice = transform.Find("Choice").GetComponent<TextMeshPro>();
        fourOfAKind = transform.Find("FourOfAKind").GetComponent<TextMeshPro>();
        fullHouse = transform.Find("FullHouse").GetComponent<TextMeshPro>();
        smallStraight = transform.Find("SmallStraight").GetComponent<TextMeshPro>();
        largeStraight = transform.Find("LargeStraight").GetComponent<TextMeshPro>();
        yacht = transform.Find("Yacht").GetComponent<TextMeshPro>();
    }

    void ResetTable() {
        currentSet = 0;
        set0Made = Made.None;
        set1Made = Made.None;
        set2Made = Made.None;
    }

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
        Yacht,
        None,
    }

    int AcesScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 1) score += 1;
        }
        int damage = 
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

    public void Hide() {
        transform.position = originPos;
    }

    public void Show() {
        transform.position = pos_;
    }
}
