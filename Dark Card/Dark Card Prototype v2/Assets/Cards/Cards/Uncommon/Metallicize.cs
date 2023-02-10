using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metallicize : Card {

    [SerializeField] int gainDexterity;

    protected override void PlayCard() {
        Player.Inst.GainDexterity(gainDexterity);
    }
}