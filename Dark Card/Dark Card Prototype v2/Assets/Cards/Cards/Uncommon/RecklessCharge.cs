using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecklessCharge : Card {

    [SerializeField] GameObject dazed;
    [SerializeField] int damage;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);

        CardManager.Inst.AddDrawPile(dazed);
        CardManager.Inst.ShuffleDrawPile();
    }
}
