using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice11 : Dice {

    int offset = 0;
    List<int> faces = new List<int>(6);

    protected override int Roll() {
        int random;
        do {
            // Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17 + offset * 19);
            random = Random.Range(0, 6);
        } while (Check(random));

        return random;
    }

    bool Check(int face) {
        for (int i = 0; i < faces.Count; i++) {
            if (faces[i] == face) {
                offset++;
                return false;
            }
        }
        offset = 0;
        faces.Add(face);
        return true;
    }

    public new void SetDice() {
        offset = 0;
        faces = new List<int>(6);
        base.SetDice();
    }
}
