using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact20 : Artifact {

    public override void EnableUpdate() {
        Player.Inst.Heal();
    }

}
