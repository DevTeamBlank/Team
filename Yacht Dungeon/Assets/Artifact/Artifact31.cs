using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact31 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fourOfAKindS);
    }

    public override int CalculateBonus(int[] num) {
        return RoundManager.Inst.currentSet == 1 ? 7 : 0;
    }
}
