using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact30 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.fullHouseS);
    }

    public override int CalculateBonus(int[] num) {
        return RoundManager.Inst.currentSet == 0 ? 7 : 0;
    }
}
