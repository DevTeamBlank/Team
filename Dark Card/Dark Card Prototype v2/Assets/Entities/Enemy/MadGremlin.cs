using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadGremlin : Enemy {

    [SerializeField] int anger = 1;

    public override void Patterns(int index) {
        switch (index) {
            case 0:
                Pattern0();
                break;
        }
    }

    public void Pattern0() {
        int damage = ApplyDamage(damages[0]);
        Player.Inst.TakeDamage(damage);
    }

    public override void TakeDamage(int value) {
        base.TakeDamage(value);
        GainStrength(anger);
    }

}
