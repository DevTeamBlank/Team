using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice17 : Dice {

    [SerializeField] Sprite[] lowSprites_ = new Sprite[6];
    [SerializeField] Sprite[] highSprites_ = new Sprite[6];

    protected override int Roll() {
        if (count == 0 || count == 2) ChangeToLow();
        if (count == 1 || count == 3) ChangeToHigh();
        Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
        return Random.Range(0, 6);
    }

    void ChangeToLow() {
        ChangeNumbers(new int[] { 1, 1, 2, 2, 3, 3 }, lowSprites_);
    }

    void ChangeToHigh() {
        ChangeNumbers(new int[] { 4, 4, 5, 5, 6, 6 }, highSprites_);
    }

}
