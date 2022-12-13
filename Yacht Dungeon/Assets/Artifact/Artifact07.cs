using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact07 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.smallStraightS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.largeStraightS);
    }

    public override int CalculateBonus(int[] num) {
        int bonus = LargeStraightScore(num);
        if (bonus == -1) {
            bonus = SmallStraightBonus(num);
        }
        return bonus;
    }

    int SmallStraightBonus(int[] num) { // Small Straight but not Large Straight
        if (Contain(num, 0) && Contain(num, 1) && Contain(num, 2) && Contain(num, 3)) {
            return 3;
        } else if (Contain(num, 1) && Contain(num, 2) && Contain(num, 3) && Contain(num, 4)) {
            return 5;
        } else if (Contain(num, 2) && Contain(num, 3) && Contain(num, 4) && Contain(num, 5)) {
            return 7;
        } else if (Contain(num, 3) && Contain(num, 4) && Contain(num, 5) && Contain(num, 6)) {
            return 9;
        } else if (Contain(num, 4) && Contain(num, 5) && Contain(num, 6) && Contain(num, 7)) {
            return 11;
        } else {
            return 0;
        }
    }

    int LargeStraightScore(int[] num) {
        if (Contain(num, 0) && Contain(num, 1) && Contain(num, 2) && Contain(num, 3) && Contain(num, 4)) {
            return 4;
        } else if (Contain(num, 1) && Contain(num, 2) && Contain(num, 3) && Contain(num, 4) && Contain(num, 5)) {
            return 6;
        } else if (Contain(num, 2) && Contain(num, 3) && Contain(num, 4) && Contain(num, 5) && Contain(num, 6)) {
            return 8;
        } else if (Contain(num, 3) && Contain(num, 4) && Contain(num, 5) && Contain(num, 6) && Contain(num, 7)) {
            return 10;
        } else { // Small Straight
            return -1;
        }
    }
}
