using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingRed : Card {

    [SerializeField] int gainEnergy;

    protected override void PlayCard() {
        Player.Inst.GainEnergy(gainEnergy);
    }
}
