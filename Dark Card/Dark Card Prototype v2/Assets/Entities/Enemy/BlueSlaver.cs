using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlaver : Enemy {

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
        int damage = ApplyDamage(damages[0]);
        Player.Inst.TakeDamage(damage);
    }

    public void Pattern1() {
        int damage = ApplyDamage(damages[1]);
        Player.Inst.TakeDamage(damage);
        Player.Inst.ApplyWeakness(1);
    }

}