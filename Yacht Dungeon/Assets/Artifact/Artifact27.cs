using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact27 : Artifact {

    public override void EnableUpdate() {
        Observer o = new Observer(this);
        o.AddSubject(RoundManager.Inst.roundStartS);

    }

    public override void Notify() {
        MadeTable.Inst.BanMade(MadeTable.Made.FourOfAKind);
        MadeTable.Inst.BanMade(MadeTable.Made.FullHouse);
    }
}
