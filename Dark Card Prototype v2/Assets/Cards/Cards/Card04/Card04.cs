using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card04 : Card { // Body Slam

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(Player.Inst.GetArmor());
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }

}
