using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pummel : Card {

    [SerializeField] int damage;
    [SerializeField] int times;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        for (int i = 0; i < times; i++) {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
        }
    }
}
