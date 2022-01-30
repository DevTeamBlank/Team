using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immolate : Card {

    [SerializeField] GameObject burn;
    [SerializeField] int damage;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);

        CardManager.Inst.AddDiscardPile(burn);
    }

}
