using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card01 : Card { // Defend_R

    [SerializeField] int armor;

    public override void Play() {
        Player.Inst.GainArmor(armor);
    }
}
