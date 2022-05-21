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

    [SerializeField] TextMeshPro[] madeDamageT_ = new TextMeshPro[12];
    [SerializeField] TextMeshPro[] madeBonusT_ = new TextMeshPro[12];
    [SerializeField] TextMeshPro setBonusT_;

    [SerializeField] GameObject aces_;
    [SerializeField] GameObject deuces_;
    [SerializeField] GameObject threes_;
    [SerializeField] GameObject fours_;
    [SerializeField] GameObject fives_;
    [SerializeField] GameObject sixes_;
    [SerializeField] GameObject choice_;
    [SerializeField] GameObject fourOfAKind_;
    [SerializeField] GameObject fullHouse_;
    [SerializeField] GameObject smallStraight_;
    [SerializeField] GameObject largeStraight_;
    [SerializeField] GameObject yacht_;

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
        MakeSubject();
        ResetTable();
    }

    void UpdateText() {
        int[] num = RoundManager.Inst.currentNumbers;
        madeDamageT_[0].text = AcesScore(num).ToString();
        madeDamageT_[1].text = DeucesScore(num).ToString();
        madeDamageT_[2].text = ThreesScore(num).ToString();
        madeDamageT_[3].text = FoursScore(num).ToString();
        madeDamageT_[4].text = FivesScore(num).ToString();
        madeDamageT_[5].text = SixesScore(num).ToString();
        madeDamageT_[6].text = ChoiceScore(num).ToString();
        madeDamageT_[7].text = FourOfAKindScore(num).ToString();
        madeDamageT_[8].text = FullHouseScore(num).ToString();
        madeDamageT_[9].text = SmallStraightScore(num).ToString();
        madeDamageT_[10].text = LargeStraightScore(num).ToString();
        madeDamageT_[11].text = YachtScore(num).ToString();

        madeBonusT_[0].text = acesS.Bonus(num).ToString();
        madeBonusT_[1].text = deucesS.Bonus(num).ToString();
        madeBonusT_[2].text = threesS.Bonus(num).ToString();
        madeBonusT_[3].text = foursS.Bonus(num).ToString();
        madeBonusT_[4].text = fivesS.Bonus(num).ToString();
        madeBonusT_[5].text = sixesS.Bonus(num).ToString();
        madeBonusT_[6].text = choiceS.Bonus(num).ToString();
        madeBonusT_[7].text = FourOfAKindScore(num) != 0 ? fourOfAKindS.Bonus(num).ToString() : "0";
        madeBonusT_[8].text = FullHouseScore(num) != 0 ? fullHouseS.Bonus(num).ToString() : "0";
        madeBonusT_[9].text = SmallStraightScore(num) != 0 ? smallStraightS.Bonus(num).ToString() : "0";
        madeBonusT_[10].text = LargeStraightScore(num) != 0 ? largeStraightS.Bonus(num).ToString() : "0";
        madeBonusT_[11].text = YachtScore(num) != 0 ? yachtS.Bonus(num).ToString() : "0";

        setBonusT_.text = setS.Bonus(num).ToString();
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

    public void SelectMade(Made made) {
        for (int i = 0; i < banMade.Count; i++) {
            if (banMade[i] == made) return;
        }
        BanMade(made);
    }
}
