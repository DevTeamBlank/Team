using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact12 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.choiceS);
        o.AddSubject(MadeTable.Inst.fourOfAKindS);
        o.AddSubject(MadeTable.Inst.fullHouseS);
    }

    public override int CalculateBonus(int[] num) {
        int[] sort = Sort(num);
        return sort[4] - sort[0];
    }
}
