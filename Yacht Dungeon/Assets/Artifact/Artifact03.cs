using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact03 : Artifact {

    public override int CalculateBonus(int[] num) {
        for (int i = 0; i < 5; i++) {
            if (2 < num[i]) return 0;
        }
        return 10;
    }
}
