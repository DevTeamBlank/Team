using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact12 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.choiceS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fourOfAKindS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fullHouseS);
    }

    public override int CalculateBonus(int[] num) {
        int[] sort = Sort(num);
        return sort[4] - sort[0];
    }
}
