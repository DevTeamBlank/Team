using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSlimeM : Enemy {

    [SerializeField] GameObject slimed;

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
        int damage = ApplyDamage(7);
        Player.Inst.TakeDamage(damage);
        CardManager.Inst.AddDiscardPile(slimed);
    }
    public void Pattern1() {
        Player.Inst.ApplyWeakness(1);
    }
    public void Pattern2() {
        int damage = ApplyDamage(10);
        Player.Inst.TakeDamage(damage);
    }

}
