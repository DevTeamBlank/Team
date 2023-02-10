using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerThrough : Card {

    [SerializeField] GameObject wound;
    [SerializeField] int armor;

    protected override void PlayCard() {
        CardManager.Inst.AddHand(GameObject.Instantiate(wound));
        CardManager.Inst.AddHand(GameObject.Instantiate(wound));

        int applyArmor = Player.Inst.ApplyArmor(armor);
        Player.Inst.GainArmor(applyArmor);
    }

}
