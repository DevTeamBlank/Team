using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact09 : Artifact {

    public override int CalculateBonus(int[] num) {
        int count = 0;
        int[] diceIndex = GetIndex();
        for (int i = 0; i < diceIndex.Length; i++) {
            if (diceIndex[i] == 0) count++;
        }
        return count;
    }
}
