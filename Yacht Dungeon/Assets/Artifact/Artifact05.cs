using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact05 : Artifact {

    public override int CalculateBonus(int[] num) {
        int count = 0;
        for (int i = 0; i < 5; i++) {
            if (num[i] % 2 == 1) count++;
        }
        return count;
    }
}
