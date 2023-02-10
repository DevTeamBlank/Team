using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBreak : Card {

    protected override void PlayCard() {
        Player.Inst.GainStrength(Player.Inst.GetStrength());
    }
}
