using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrench : Card {

    protected override void PlayCard() {
        Player.Inst.GainArmor(Player.Inst.GetArmor());
    }
}
