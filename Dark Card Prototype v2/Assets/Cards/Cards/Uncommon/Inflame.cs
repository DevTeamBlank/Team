using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflame : Card {

    [SerializeField] int gainStrength;

    protected override void PlayCard() {
        Player.Inst.GainStrength(gainStrength);
    }
}
