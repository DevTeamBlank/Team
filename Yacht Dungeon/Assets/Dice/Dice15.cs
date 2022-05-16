using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice15 : Dice {

    int prevFace;

    protected override int Roll() {
        if (count == 0) {
            Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(0, 6);
        } else if (count == 1) {
            prevFace = face;
            canTrigger = true;
            Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(0, 6);
        } else {
            prevFace = face;
            Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(0, 6);
        }
    }

    protected override void Trigger() {
        face = prevFace;
        GetComponent<SpriteRenderer>().sprite = sprites_[face];
    }

    public new void SetDice() {
        prevFace = 0;
        base.SetDice();
    }
}
