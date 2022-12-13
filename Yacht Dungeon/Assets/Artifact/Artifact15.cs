using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact15 : Artifact {

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.choiceS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.fullHouseS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.largeStraightS);
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.yachtS);
    }

    public override int CalculateBonus(int[] num) {
        return 5;
    }
}
