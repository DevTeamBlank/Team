using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PommelStrike : Card {

    [SerializeField] int damage;
    [SerializeField] int draw;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
        CardManager.Inst.DrawCards(draw);
    }
}
