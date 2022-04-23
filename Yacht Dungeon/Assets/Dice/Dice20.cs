using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice20 : Dice {

    public override void GetDice(int set, int place) {
        ChangeNumbersTo(place + 1);
    }

    void ChangeNumbersTo(int i) {
        ChangeNumbers(new int[] { i, i, i, i + 1, i + 1, i + 1 }, MakeSprite(i));
    }
    Sprite[] MakeSprite(int num) {
        Sprite[] ret = new Sprite[6];
        for (int i = 0; i < 3; i++) {
            ret[i] = sprites_[num - 1];
        }
        for (int i = 3; i < 6; i++) {
            ret[i] = sprites_[num];
        }
        return ret;
    }
}
