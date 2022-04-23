using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact29 : Artifact {

    public override void EnableMade() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.smallStraightS);
        o.AddSubject(MadeTable.Inst.largeStraightS);
    }

    public override int CalculateBonus(int[] num) {
        for (int i = 0; i < 5; i++) {
            if (num[i] == 6) {
                return 5;
            }
        }
        return 0;
    }
}
