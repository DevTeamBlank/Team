using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact37 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fourOfAKindS);
    }

    public override int CalculateBonus(int[] num) {
        return 5;
    }
}
