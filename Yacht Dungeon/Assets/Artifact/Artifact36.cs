using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact36 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fullHouseS);
    }

    public override int CalculateBonus(int[] num) {
        return 5;
    }
}
