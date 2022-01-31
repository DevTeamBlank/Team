using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : Card {

    protected override void PlayCard() {
        Player.Inst.ApplyBarricade(true);
    }
}
