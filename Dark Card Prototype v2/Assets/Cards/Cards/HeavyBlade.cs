using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBlade : Card {

    [SerializeField] int damage;
    [SerializeField] int times;

    protected override void PlayCard() {
        int applyDamage = damage;
        for (int i = 0; i < times; i++) {
            applyDamage = Player.Inst.ApplyDamage(applyDamage);
        }
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}
