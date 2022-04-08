using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact00 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.smallStraightS);
        o.AddSubject(MadeTable.Inst.largeStraightS);
    }

    public override int CalculateBonus() {
        return 5;
    }

}
