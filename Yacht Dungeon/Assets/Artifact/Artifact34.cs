using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact34 : Artifact {
    public override int CalculateBonus(int[] num) {
        return RoundManager.Inst.currentSet == 2 ? 4 : 0;
    }
}
