using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact08 : Artifact {

    public override int CalculateBonus(int[] num) {
        GameObject[] dices = GetDice();
        int count = 0;
        for (int i = 0; i < dices.Length; i++) {
            count += dices[i].GetComponent<Dice>().GetReroll();
        }
        return count;
    }

}
