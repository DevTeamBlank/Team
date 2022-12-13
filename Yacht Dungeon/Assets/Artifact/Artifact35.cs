using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact35 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.yachtS);
    }

    public override int CalculateBonus(int[] num) {
        return 20;
    }
}
