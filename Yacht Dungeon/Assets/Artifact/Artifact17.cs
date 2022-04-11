using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact17 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.smallStraightS);
        o.AddSubject(MadeTable.Inst.largeStraightS);
        o.AddSubject(MadeTable.Inst.yachtS);
    }

    public override int CalculateBonus(int[] num) {
        return 3;
    }
}
