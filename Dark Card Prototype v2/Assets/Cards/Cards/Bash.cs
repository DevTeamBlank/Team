using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : Card { // Bash

    [SerializeField] int damage;
    [SerializeField] int vulnerable;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ApplyVulnerable(vulnerable, attackType);
    }
}
