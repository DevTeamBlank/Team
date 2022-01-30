using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rampage : Card {

    [SerializeField] int damage;
    [SerializeField] int extra;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
        damage += extra;
    }
}
