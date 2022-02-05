using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Enemy {

    [SerializeField] int count = 0;

    protected override void DecidePattern() {
        currPattern = (count < 2) ? 0 : 1;
        UpdateIntent(intents[currPattern]);
        UpdateDamage(damages[currPattern]);
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

    public void Pattern0() {
        count++;
        int damage = ApplyDamage(damages[0]);
        Player.Inst.TakeDamage(damage);
    }

    public void Pattern1() {
        Player.Inst.TakeDamage(damages[1]);
        TakeDamage(maxHealth);
    }
}
