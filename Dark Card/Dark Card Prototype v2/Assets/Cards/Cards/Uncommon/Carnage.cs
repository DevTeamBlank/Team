using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnage : Card {

    [SerializeField] int damage;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}
