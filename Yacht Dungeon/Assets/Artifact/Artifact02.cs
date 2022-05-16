using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact02 : Artifact {

    public override void EnableUpdate() {
        int[,] indexes = DiceManager.Inst.diceIndex;
        for (int i = 0; i < 5; i++) {
            if (indexes[0, i] == 0) {
                DiceManager.Inst.set1[i].GetComponent<Dice>().IncreaseReroll();
            }
        }
        for (int i = 0; i < 5; i++) {
            if (indexes[1, i] == 0) {
                DiceManager.Inst.set2[i].GetComponent<Dice>().IncreaseReroll();
            }
        }
        for (int i = 0; i < 5; i++) {
            if (indexes[2, i] == 0) {
                DiceManager.Inst.set3[i].GetComponent<Dice>().IncreaseReroll();
            }
        }
    }

}
