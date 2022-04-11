using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact13 : Artifact {

    public override int CalculateBonus(int[] num) {
        int count = 0;
        for (int i = 0; i < num.Length; i++) {
            if (num[i] == 1) count++;
        }
        return (2 <= count) ? 5 : 0;
    }
}
