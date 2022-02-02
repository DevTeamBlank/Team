using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : Enemy {

    [SerializeField] int ritual = 3;
    bool isRitual;

    public override void BattleStart() {
        DecidePattern(true);
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
        UpdateIntent();
        UpdateDamage();
    }

    public override void TurnEnd() {
        DecreaseWeakness();
        if (isRitual) {
            GainStrength(ritual);
        }
        DecidePattern(false);
    }

    public void Pattern0() {
        isRitual = true;
    }

    public void Pattern1() {
        int damage = ApplyDamage(damages[1]);
        Player.Inst.TakeDamage(damage);
    }
}
