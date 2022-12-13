using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact33 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.largeStraightS);
    }

    public override int CalculateBonus(int[] num) {
        return RoundManager.Inst.currentSet == 2 ? 7 : 0;
    }
}
