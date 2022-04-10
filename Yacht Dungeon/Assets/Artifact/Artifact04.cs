using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact04 : Artifact { 

    public override int CalculateBonus(int[] num) {
        return Kinds(GetIndex());
    }

    int[] GetIndex() {
        int set = RoundManager.Inst.currentSet;
        int[] dices = new int[5];
        for (int i = 0; i < 5; i++) {
            dices[i] = DiceManager.Inst.diceIndex[set, i];
        }
        return dices;
    }

    int Kinds(int[] nums) {
        int ret = 1;
        for (int i = 1; i < nums.Length; i++) {
            bool flag = true;
            for (int j = 0; j < i; j++) {
                if (nums[i] == nums[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                ret++;
            }
        }
        return ret;
    }
}
