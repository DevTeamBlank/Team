using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsor : Enemy {

    [SerializeField] GameObject dazed;
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
        for (int i = 0; i < 2; i++) {
            CardManager.Inst.AddDrawPile(GameObject.Instantiate(dazed));
        }
    }

}
