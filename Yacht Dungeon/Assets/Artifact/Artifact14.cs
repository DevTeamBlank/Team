using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact14 : Artifact {

    public override int CalculateBonus(int[] num) {
        for (int i = 0; i < num.Length; i++) {
            if (num[i] != 5 && num[i] != 6) return 0;
        }
        return 5;
    }
}
