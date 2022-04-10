using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice16 : Dice {
    protected override int Roll() {
        if (count == 0 || count == 2) ChangeToOdd();
        if (count == 1 || count == 3) ChangeToEven();
        Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
        return Random.Range(0, 6);
    }

    void ChangeToOdd() {
        ChangeNumbers(new int[] { 1, 1, 3, 3, 5, 5 });
    }

    void ChangeToEven() {
        ChangeNumbers(new int[] { 2, 2, 4, 4, 6, 6 });
    }

}
