using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact18 : Artifact {

    public override int CalculateBonus(int[] num) {
        switch (RoundManager.Inst.currentRoll) {
            case 1:
                return 5;
            case 2:
                return 3;
            case 3:
                return 1;
            case 4:
                return 0;
            default:
                Debug.Log("Error");
                return 0;
        }
    }
}
