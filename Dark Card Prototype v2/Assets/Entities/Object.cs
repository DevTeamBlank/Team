using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : Entity {

    public int ObjectID;

    protected override void Dead() {
        base.Dead();
        GetComponentInParent<LevelManager>().ObjectDestroyed(index);
    }
}
