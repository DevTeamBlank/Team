using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact39 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.largeStraightS);
    }

    public override int CalculateBonus(int[] num) {
        return 5;
    }
}
