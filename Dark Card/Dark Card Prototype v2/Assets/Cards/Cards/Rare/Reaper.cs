using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : Card {

    [SerializeField] int damage;
    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        Player.Inst.HealHealth(applyDamage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}
