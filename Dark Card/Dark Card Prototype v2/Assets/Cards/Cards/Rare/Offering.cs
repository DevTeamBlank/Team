using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offering : Card {

    [SerializeField] int loseHealth;
    [SerializeField] int gainEnergy;
    [SerializeField] int draw;

    protected override void PlayCard() {
        Player.Inst.LossHealth(loseHealth);
        Player.Inst.GainEnergy(gainEnergy);
        CardManager.Inst.DrawCards(draw);
    }
}
