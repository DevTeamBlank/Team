using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawWorm : Enemy {
    public override void Patterns(int index) {
        switch (index) {
            case 0:
                Pattern0();
                break;
            case 1:
                Pattern1();
                break;
            case 2:
                Pattern2();
                break;
        }
    }

    public void Pattern0() {
        int damage = ApplyDamage(damages[0]);
        Player.Inst.TakeDamage(damage);
    }

    [SerializeField] int thrashArmor = 5;

    public void Pattern1() {
        int damage = ApplyDamage(damages[1]);
        Player.Inst.TakeDamage(damage);
        GainArmor(thrashArmor);
    }

    [SerializeField] int bellowStrength;
    [SerializeField] int bellowArmor;

    public void Pattern2() {
        GainStrength(bellowStrength);
        GainArmor(bellowArmor);
    }
}
