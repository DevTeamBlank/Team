using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact23 : Artifact {

    [SerializeField] int count = 2;

    public override void EnableMade() {
        observer.GetComponent<Observer>().AddSubject(MadeTable.Inst.yachtS);
    }

    public override int CalculateBonus(int[] num) {
        if (0 < count) {
            Player.Inst.Heal();
            count--;
        }
        return 0;
    }
}
