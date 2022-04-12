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
    TextMeshPro deucesT;
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

    TextMeshPro acesBT;
    TextMeshPro deucesBT;
    TextMeshPro threesBT;
    TextMeshPro foursBT;
    TextMeshPro fivesBT;
    TextMeshPro sixesBT;
    TextMeshPro choiceBT;
    TextMeshPro fourOfAKindBT;
    TextMeshPro fullHouseBT;
    TextMeshPro smallStraightBT;
    TextMeshPro largeStraightBT;
    TextMeshPro yachtBT;

    TextMeshPro setBT;

    [HideInInspector] public Subject acesS;
    [HideInInspector] public Subject deucesS;
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

    [HideInInspector] public Subject setS;

    [SerializeField] int currentSet;
    [SerializeField] List<Made> banMade;

    private void Start() {
        FindText();
        MakeSubject();
        ResetTable();
    }

    void FindText() {
        acesT = transform.Find("Aces").GetComponent<TextMeshPro>();
        deucesT = transform.Find("Deuces").GetComponent<TextMeshPro>();
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

        acesBT = transform.Find("AcesB").GetComponent<TextMeshPro>();
        deucesBT = transform.Find("DeucesB").GetComponent<TextMeshPro>();
        threesBT = transform.Find("ThreesB").GetComponent<TextMeshPro>();
        foursBT = transform.Find("FoursB").GetComponent<TextMeshPro>();
        fivesBT = transform.Find("FivesB").GetComponent<TextMeshPro>();
        sixesBT = transform.Find("SixesB").GetComponent<TextMeshPro>();
        choiceBT = transform.Find("ChoiceB").GetComponent<TextMeshPro>();
        fourOfAKindBT = transform.Find("FourOfAKindB").GetComponent<TextMeshPro>();
        fullHouseBT = transform.Find("FullHouseB").GetComponent<TextMeshPro>();
        smallStraightBT = transform.Find("SmallStraightB").GetComponent<TextMeshPro>();
        largeStraightBT = transform.Find("LargeStraightB").GetComponent<TextMeshPro>();
        yachtBT = transform.Find("Yacht").GetComponent<TextMeshPro>();

        setBT = transform.Find("SetB").GetComponent<TextMeshPro>();
    }

    void UpdateText() {
        int[] num = RoundManager.Inst.currentNumbers;
        acesT.text = AcesScore(num).ToString();
        deucesT.text = DeucesScore(num).ToString();
        threesT.text = ThreesScore(num).ToString();
        foursT.text = FoursScore(num).ToString();
        fivesT.text = FivesScore(num).ToString();
        sixesT.text = SixesScore(num).ToString();
        choiceT.text = ChoiceScore(num).ToString();
        fourOfAKindT.text = FourOfAKindScore(num).ToString();
        fullHouseT.text = FullHouseScore(num).ToString();
        smallStraightT.text = SmallStraightScore(num).ToString();
        largeStraightT.text = LargeStraightScore(num).ToString();
        yachtT.text = YachtScore(num).ToString();

        acesBT.text = acesS.Bonus(num).ToString();
        deucesBT.text = deucesS.Bonus(num).ToString();
        threesBT.text = threesS.Bonus(num).ToString();
        foursBT.text = foursS.Bonus(num).ToString();
        fivesBT.text = fivesS.Bonus(num).ToString();
        sixesBT.text = sixesS.Bonus(num).ToString();
        choiceBT.text = choiceS.Bonus(num).ToString();
        fourOfAKindBT.text = FourOfAKindScore(num) != 0 ? fourOfAKindS.Bonus(num).ToString() : "0";
        fullHouseBT.text = FullHouseScore(num) != 0 ? fullHouseS.Bonus(num).ToString() : "0";
        smallStraightBT.text = SmallStraightScore(num) != 0 ? smallStraightS.Bonus(num).ToString() : "0";
        largeStraightBT.text = LargeStraightScore(num) != 0 ? largeStraightS.Bonus(num).ToString() : "0";
        yachtBT.text = YachtScore(num) != 0 ? yachtS.Bonus(num).ToString() : "0";

        setBT.text = setS.Bonus(num).ToString();
    }

    void MakeSubject() {
        acesS = new Subject();
        deucesS = new Subject();
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

        setS = new Subject();
    }

    void ResetTable() {
        currentSet = 0;
        banMade = new List<Made>();
    }

    public enum Made {
        Aces,
        Deuces,
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

    public void BanMade(Made m) {
        banMade.Add(m);
    }

    void InactiveMade() {
        for(int i = 0; i < banMade.Count; i++) {
            // TODO
            // Blur Texts
            // Inactive buttons
        }
    }

    int AcesScore(int[] num) {
        int score = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] == 1) score += 1;
        }
        return score;
    }

    int DeucesScore(int[] num) {
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

    bool Contain(int[] num, int n) {
        for (int i = 0; i < num.Length; i++) {
            if (num[i] == n) return true;
        }
        return false;
    }

    int SmallStraightScore(int[] num) {
        if (Contain(num, 0) && Contain(num, 1) && Contain(num, 2) && Contain(num, 3)) {
            return 15;
        } else if (Contain(num, 1) && Contain(num, 2) && Contain(num, 3) && Contain(num, 4)) {
            return 15;
        } else if (Contain(num, 2) && Contain(num, 3) && Contain(num, 4) && Contain(num, 5)) {
            return 15;
        } else if (Contain(num, 3) && Contain(num, 4) && Contain(num, 5) && Contain(num, 6)) {
            return 15;
        } else if (Contain(num, 4) && Contain(num, 5) && Contain(num, 6) && Contain(num, 7)) {
            return 15;
        } else {
            return 0;
        }
    }

    int LargeStraightScore(int[] num) {
        if (Contain(num, 0) && Contain(num, 1) && Contain(num, 2) && Contain(num, 3) && Contain(num, 4)) {
            return 30;
        } else if (Contain(num, 1) && Contain(num, 2) && Contain(num, 3) && Contain(num, 4) && Contain(num, 5)) {
            return 30;
        } else if (Contain(num, 2) && Contain(num, 3) && Contain(num, 4) && Contain(num, 5) && Contain(num, 6)) {
            return 30;
        } else if (Contain(num, 3) && Contain(num, 4) && Contain(num, 5) && Contain(num, 6) && Contain(num, 7)) {
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

    public void UpdateMadeTable() {
        UpdateText();
        InactiveMade();
    }

    void Appear() {
        // TODO
        // change position
    }

    RaycastHit2D hit;
    GameObject go;

    public bool canSelectMade = false;

    private void Update() {
        SelectMade();
    }

    void SelectMade() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (CanSelectMade()) {
                go = hit.transform.gameObject;
                if (go.name == "Aces") {
                    Select(Made.Aces);
                } else if (go.name == "Deuces") {
                    Select(Made.Deuces);
                } else if (go.name == "Threes") {
                    Select(Made.Threes);
                } else if (go.name == "Fours") {
                    Select(Made.Fours);
                } else if (go.name == "Fives") {
                    Select(Made.Fives);
                } else if (go.name == "Sixes") {
                    Select(Made.Sixes);
                } else if (go.name == "Choice") {
                    Select(Made.Choice);
                } else if (go.name == "4 Of A Kind") {
                    Select(Made.FourOfAKind);
                } else if (go.name == "Full House") {
                    Select(Made.FullHouse);
                } else if (go.name == "Small Straight") {
                    Select(Made.SmallStraight);
                } else if (go.name == "Large Straight") {
                    Select(Made.LargeStragith);
                } else if (go.name == "Yacht") {
                    Select(Made.Yacht);
                }
            } else {
                Debug.Log(hit);
            }
        }
    }

    void Select(Made made) {
        for (int i = 0; i < banMade.Count; i++) {
            if (banMade[i] == made) return;
        }
        BanMade(made);


    }

    bool CanSelectMade() {
        return hit && canSelectMade;
    }

    public void RoundStart() {
        canSelectMade = false;
    }

}
