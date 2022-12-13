using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact32 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.smallStraightS);
    }

    public override int CalculateBonus(int[] num) {
        return RoundManager.Inst.currentSet == 2 ? 7 : 0;
    }
}
