using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hemokinesis : Card {

    [SerializeField] int loseHealth;
    [SerializeField] int damage;

    protected override void PlayCard() {
        Player.Inst.LossHealth(loseHealth);
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}
