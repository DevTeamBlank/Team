using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice20 : Dice {

    public override void GetDice(int set, int place) {
        ChangeNumbersTo(place + 1);
    }

    void ChangeNumbersTo(int i) {
        ChangeNumbers(new int[] { i, i, i, i, i, i });
    }
}
