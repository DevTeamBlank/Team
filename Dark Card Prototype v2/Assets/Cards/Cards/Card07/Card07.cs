using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card07 : Card { // Clothesline

    [SerializeField] int damage;
    [SerializeField] int weakness;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ApplyWeakness(weakness, attackType);
    }
}
