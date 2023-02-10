using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : Card {
    public override void Drawn() {
        Player.Inst.UseEnergy(1) ;
    }
}
