using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice27 : Dice {

    bool isIncreasing;

    protected override int Roll() {
        if (count == 0) {
            canTrigger = true;
            Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(0, 6);
        }

        if (isIncreasing) {
            if (face == 5) return 5;
            Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(face + 1, 6);
        } else {
            if (face == 0) return 0;
            Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(0, face);
        }

    }

    protected override void Trigger() {
        isIncreasing = false;
    }

    public new void SetDice() {
        base.SetDice();
        isIncreasing = true;
    }
}
