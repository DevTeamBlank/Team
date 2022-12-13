using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact01 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.choiceS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fourOfAKindS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fullHouseS);
    }

    public override int CalculateBonus(int[] num) {
        return 3;
    }
}
