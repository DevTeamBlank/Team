using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrugItOff : Card {

    [SerializeField] int armor;
    [SerializeField] int draw;

    protected override void PlayCard() {
        int applyArmor = Player.Inst.ApplyArmor(armor);
        Player.Inst.GainArmor(applyArmor);
        CardManager.Inst.DrawCards(draw);
    }
}
