using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card01 : Card { // Defend_R

    [SerializeField] int armor;

    public override void Play(GameObject target) {
        Player.Inst.GainArmor(armor);
    }
}
