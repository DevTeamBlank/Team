using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardGremlin : Enemy {

    [SerializeField] int charge = 0;

    protected override void DecidePattern() {
        currPattern = (charge < 2) ? 0 : 1;
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
        charge++;
    }

    public void Pattern1() {
        int damage = ApplyDamage(damages[1]);
        Player.Inst.TakeDamage(damage);
        charge = 0;
    }
}
