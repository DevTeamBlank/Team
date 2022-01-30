using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike_R : Card { // Attack_R

    [SerializeField] int damage;
    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}

