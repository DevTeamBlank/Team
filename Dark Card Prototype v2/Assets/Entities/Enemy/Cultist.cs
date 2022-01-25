using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : Enemy {

    [SerializeField] int ritual = 3;
    bool isRitual;

    public override void BattleStart() {
        DecidePattern(true);
    }

    public override void TurnStart() {
        Patterns(currPattern);
    }


    public override void Patterns(int index) {
        switch (index) {
            case 0:
                Pattern0();
                break;
            case 1:
                Pattern1();
                break;
        }
    }


    protected void DecidePattern(bool isFirstTurn) {
        currPattern = isFirstTurn ? 0 : 1;
        transform.Find("Intent").GetComponent<SpriteRenderer>().sprite = intents[currPattern];
    }

    public override void TurnEnd() {
        if (isRitual) {
            GainStrength(ritual);
        }
        DecidePattern(false);
    }

    public void Pattern0() {
        isRitual = true;
        Debug.Log("Ritual " + ritual + " gained.");
    }
    public void Pattern1() {
        int damage = ApplyDamage(6);
        Player.Inst.TakeDamage(damage);
    }
}
