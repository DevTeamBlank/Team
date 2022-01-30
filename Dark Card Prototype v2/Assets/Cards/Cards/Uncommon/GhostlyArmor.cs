using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostlyArmor : Card {

    [SerializeField] int armor;

    protected override void PlayCard() {
        int applyArmor = Player.Inst.ApplyArmor(armor);
        Player.Inst.GainArmor(applyArmor);
    }

}
