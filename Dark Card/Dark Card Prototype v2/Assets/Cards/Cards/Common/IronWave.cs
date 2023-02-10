using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronWave : Card {

    [SerializeField] int armor;
    [SerializeField] int damage;

    protected override void PlayCard() {
        int applyArmor = Player.Inst.ApplyArmor(armor);
        Player.Inst.GainArmor(applyArmor);
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}