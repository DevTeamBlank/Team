using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : Entity {

    protected override void Dead() {
        base.Dead();
        GetComponentInParent<LevelManager>().ArtifactDestroyed(index);
    }
}
