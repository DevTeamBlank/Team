using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact32 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.smallStraightS);
    }

    public override int CalculateBonus(int[] num) {
        return RoundManager.Inst.currentSet == 1 ? 7 : 0;
    }
}
