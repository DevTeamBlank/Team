using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Card {
    public override void TurnEnd() {
        Player.Inst.TakeDamage(2);
    }
}
