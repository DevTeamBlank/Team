using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildStrike : Card {

    [SerializeField] GameObject wound;
    [SerializeField] int damage;
    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
        CardManager.Inst.AddDrawPile(wound);
        CardManager.Inst.ShuffleDrawPile();
    }

}
