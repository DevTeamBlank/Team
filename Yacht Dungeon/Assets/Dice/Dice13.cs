using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice13 : Dice {
    protected override int Roll() {
        if (count == 0) {
            // Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(0, 6);
        } else {
            // Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(face, 6);
        }
    }

}
