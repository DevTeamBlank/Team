using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact21 : Artifact {

    public override void EnableUpdate() {
        Player.Inst.SetChoice(Player.Inst.GetChoice() + 1);
    }

}
