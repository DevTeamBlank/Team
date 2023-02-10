using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodletting : Card {

    [SerializeField] int loseHealth;
    [SerializeField] int gainEnergy;

    protected override void PlayCard() {
        Player.Inst.LossHealth(loseHealth);
        Player.Inst.GainEnergy(gainEnergy);
    }
}
