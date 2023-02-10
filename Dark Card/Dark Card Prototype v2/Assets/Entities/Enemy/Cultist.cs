using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : Enemy {

    [SerializeField] int ritual = 3;
    [SerializeField] bool isRitual = false;

    public override void BattleStart() {
        DecidePattern();
    }

    protected override void DecidePattern() {
        currPattern = isRitual ? 1 : 0;
        UpdateIntent();
        UpdateDamage();
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

    public override void TurnEnd() {
        DecreaseWeakness();
        if (isRitual) {
            GainStrength(ritual);
        }
        DecidePattern();
    }

    public void Pattern0() {
        isRitual = true;
    }

    public void Pattern1() {
        int damage = ApplyDamage(damages[1]);
        Player.Inst.TakeDamage(damage);
    }
}
