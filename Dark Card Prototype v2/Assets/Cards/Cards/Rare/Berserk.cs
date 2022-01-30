using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : Card {

    [SerializeField] int vulnerable;
    [SerializeField] int extraEnergy;

    protected override void PlayCard() {
        Player.Inst.ApplyVulnerable(vulnerable);
        Player.Inst.turnEnergy += extraEnergy;
    }
}
