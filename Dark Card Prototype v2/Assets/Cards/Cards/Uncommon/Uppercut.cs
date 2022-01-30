using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppercut : Card {

    [SerializeField] int damage;
    [SerializeField] int weakness;
    [SerializeField] int vulnerable;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ApplyWeakness(weakness, attackType);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ApplyVulnerable(vulnerable, attackType);
    }
}
