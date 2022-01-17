using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card02 : Card { // Attack_R

    [SerializeField] int damage;
    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage);
    }
}

