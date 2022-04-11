using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact15 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        // Need check
        o.AddSubject(MadeTable.Inst.choiceS);
        o.AddSubject(MadeTable.Inst.fullHouseS);
        o.AddSubject(MadeTable.Inst.largeStraightS);
        o.AddSubject(MadeTable.Inst.yachtS);
    }

    public override int CalculateBonus(int[] num) {
        return 5;
    }
}
