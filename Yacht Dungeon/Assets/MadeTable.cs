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

    TextMeshPro acesT;
    TextMeshPro ducesT;
    TextMeshPro threesT;
    TextMeshPro foursT;
    TextMeshPro fivesT;
    TextMeshPro sixesT;
    TextMeshPro choiceT;
    TextMeshPro fourOfAKindT;
    TextMeshPro fullHouseT;
    TextMeshPro smallStraightT;
    TextMeshPro largeStraightT;
    TextMeshPro yachtT;

    [HideInInspector] public Subject acesS;
    [HideInInspector] public Subject ducesS;
    [HideInInspector] public Subject threesS;
    [HideInInspector] public Subject foursS;
    [HideInInspector] public Subject fivesS;
    [HideInInspector] public Subject sixesS;
    [HideInInspector] public Subject choiceS;
    [HideInInspector] public Subject fourOfAKindS;
    [HideInInspector] public Subject fullHouseS;
    [HideInInspector] public Subject smallStraightS;
    [HideInInspector] public Subject largeStraightS;
    [HideInInspector] public Subject yachtS;

    [SerializeField] int currentSet;
    [SerializeField] List<Made> banMade;

    private void Start() {
        FindText();
        MakeSubject();
        ResetTable();
    }

    void FindText() {
        acesT = transform.Find("Aces").GetComponent<TextMeshPro>();
        ducesT = transform.Find("Duces").GetComponent<TextMeshPro>();
        threesT = transform.Find("Threes").GetComponent<TextMeshPro>();
        foursT = transform.Find("Fours").GetComponent<TextMeshPro>();
        fivesT = transform.Find("Fives").GetComponent<TextMeshPro>();
        sixesT = transform.Find("Sixes").GetComponent<TextMeshPro>();
        choiceT = transform.Find("Choice").GetComponent<TextMeshPro>();
        fourOfAKindT = transform.Find("FourOfAKind").GetComponent<TextMeshPro>();
        fullHouseT = transform.Find("FullHouse").GetComponent<TextMeshPro>();
        smallStraightT = transform.Find("SmallStraight").GetComponent<TextMeshPro>();
        largeStraightT = transform.Find("LargeStraight").GetComponent<TextMeshPro>();
        yachtT = transform.Find("Yacht").GetComponent<TextMeshPro>();
    }

    void MakeSubject() {
        acesS = new Subject();
        ducesS = new Subject();
        threesS = new Subject();
        foursS = new Subject();
        fivesS = new Subject();
        sixesS = new Subject();
        choiceS = new Subject();
        fourOfAKindS = new Subject();
        fullHouseS = new Subject();
        smallStraightS = new Subject();
        largeStraightS = new Subject();
        yachtS = new Subject();
    }

    void ResetTable() {
        currentSet = 0;
        banMade = new List<Made>();
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
        Yacht
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
