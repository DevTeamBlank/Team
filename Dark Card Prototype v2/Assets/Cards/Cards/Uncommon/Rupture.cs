using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupture : Card {

    [SerializeField] int loseHealth;
    [SerializeField] int gainStrength;

    protected override void PlayCard() {
        Player.Inst.LossHealth(loseHealth);
        Player.Inst.GainStrength(gainStrength);
    }
}
