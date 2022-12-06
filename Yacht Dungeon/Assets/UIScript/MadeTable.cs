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

    [SerializeField] GameObject[] madeDamageT_ = new GameObject[12];
    [SerializeField] int[] madeDamage = new int[12];
    [SerializeField] GameObject[] madeBonusT_ = new GameObject[12];
    [SerializeField] int[] madeBonus = new int[12];
    [SerializeField] GameObject setBonusT_;
    [SerializeField] int setBonus;

    [SerializeField] GameObject[] madeBar_ = new GameObject[12];

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

    [SerializeField] List<Made> banMade;

    private void Start() {
        MakeSubject();
        ResetTable();
    }

    void UpdateText() {
        int[] num = RoundManager.Inst.currentNumbers;

        for (int i = 0; i < 12; i++) {
            madeDamage[i] = Score(num, (Made)i);
            DamageUpdate((Made)i, madeDamage[i]);

            madeBonus[i] = Bonus(num, (Made)i);
            BonusUpdate((Made)i, madeBonus[i]);
        }

        setBonus = setS.Bonus(num);
        SetBonusUpdate(setBonus);
    }

    public void StartSet() {
        for (int i = 0; i < 12; i++) {
            DamageUpdate((Made)i, 0);
        }
    }

    void DamageUpdate(Made made, int damage) {
        int index = MadeToInt(made);
        Vector3 pos = madeDamageT_[index].transform.position;
        TextManager.Inst.ChangeText(damage, madeDamageT_[index], TextManager.TextMode.Default);
        madeDamageT_[index].transform.position = pos;
        madeDamageT_[index].name = made.ToString() + " Damage: " + damage.ToString();
    }

    void BonusUpdate(Made made, int damage) {
        int index = MadeToInt(made);
        Vector3 pos = madeBonusT_[index].transform.position;
        TextManager.Inst.ChangeText(damage, madeBonusT_[index], TextManager.TextMode.Default);
        madeBonusT_[index].transform.position = pos;
        madeBonusT_[index].name = made.ToString() + " Bonus: " + damage.ToString();
    }

    void SetBonusUpdate(int damage) {
        Vector3 pos = setBonusT_.transform.position;
        TextManager.Inst.ChangeText(damage, setBonusT_, TextManager.TextMode.Default);
        setBonusT_.transform.position = pos;
        setBonusT_.name = "Set Bonus: " + damage.ToString();
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
        LargeStraight,
        Yacht
    }

    int MadeToInt(Made made) {
        switch (made) {
            case Made.Aces:
                return 0;
            case Made.Deuces:
                return 1;
            case Made.Threes:
                return 2;
            case Made.Fours:
                return 3;
            case Made.Fives:
                return 4;
            case Made.Sixes:
                return 5;
            case Made.Choice:
                return 6;
            case Made.FourOfAKind:
                return 7;
            case Made.FullHouse:
                return 8;
            case Made.SmallStraight:
                return 9;
            case Made.LargeStraight:
                return 10;
            case Made.Yacht:
                return 11;
            default:
                return -1;
        }
    }

    public void BanMade(Made m) {
        banMade.Add(m);
    }

    public void InactiveMade() {
        for (int i = 0; i < banMade.Count; i++) {
            madeBar_[(int)banMade[i]].GetComponent<MadeTableBar>().BanMade();
        }
    }

    public int Score(int[] num, Made made) {
        switch (made) {
            case Made.Aces:
                return AcesScore(num);
            case Made.Deuces:
                return DeucesScore(num);
            case Made.Threes:
                return ThreesScore(num);
            case Made.Fours:
                return FoursScore(num);
            case Made.Fives:
                return FivesScore(num);
            case Made.Sixes:
                return SixesScore(num);
            case Made.Choice:
                return ChoiceScore(num);
            case Made.FourOfAKind:
                return FourOfAKindScore(num);
            case Made.FullHouse:
                return FullHouseScore(num);
            case Made.SmallStraight:
                return SmallStraightScore(num);
            case Made.LargeStraight:
                return LargeStraightScore(num);
            case Made.Yacht:
                return YachtScore(num);
            default:
                return -1;
        }
    }

    public int Bonus(int[] num, Made made) {
        switch (made) {
            case Made.Aces:
                return acesS.Bonus(num);
            case Made.Deuces:
                return deucesS.Bonus(num);
            case Made.Threes:
                return threesS.Bonus(num);
            case Made.Fours:
                return foursS.Bonus(num);
            case Made.Fives:
                return fivesS.Bonus(num);
            case Made.Sixes:
                return sixesS.Bonus(num);
            case Made.Choice:
                return choiceS.Bonus(num);
            case Made.FourOfAKind:
                return FourOfAKindScore(num) != 0 ? fourOfAKindS.Bonus(num) : 0;
            case Made.FullHouse:
                return FullHouseScore(num) != 0 ? fullHouseS.Bonus(num) : 0;
            case Made.SmallStraight:
                return SmallStraightScore(num) != 0 ? smallStraightS.Bonus(num) : 0;
            case Made.LargeStraight:
                return LargeStraightScore(num) != 0 ? largeStraightS.Bonus(num) : 0;
            case Made.Yacht:
                return YachtScore(num) != 0 ? yachtS.Bonus(num) : 0;
            default:
                return -1;
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
        int damage = madeDamage[(int)made] + madeBonus[(int)made] + setBonus;
        
        RoundManager.Inst.GetComponent<RoundManager>().SetDamage(damage);
    }

}
