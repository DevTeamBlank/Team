using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleave : Card { // Cleave

    [SerializeField] int damage;
    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}
