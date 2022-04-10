using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice19 : Dice {

    public override void GetDice(int set, int place) {
        ChangeNumbersTo(place);
    }

    void ChangeNumbersTo(int i) {
        ChangeNumbers(new int[] { i, i, i, i, i, i });
    }
}
