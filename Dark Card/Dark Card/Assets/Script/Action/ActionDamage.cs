using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDamage {

    public int damage;

    public bool trueDamage; // 아이템, 독, 장비 등에 의한 피해
    public bool penetrateBlock; // 독 등에 의한 피해

    public bool fatal; // 치명타 보너스
    public Action fatalAction;

    public ActionDamage(int i, bool b0 = false, bool b1 = false, bool b2 = false, Action a = null) {
        damage = i;
        trueDamage = b0;
        penetrateBlock = b1;
        fatal = b2;
        fatalAction = a;
    }

}
