using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : Entity {

    protected GameObject levelManager;
    protected LevelManager.Status status;

    public override void TurnStart() {
        base.TurnStart();
        ArtifactTurnStart();
    }

    protected virtual void ArtifactTurnStart() { }

    public override void TurnEnd() {
        base.TurnEnd();
    }

    public override void BattleStart() {
        levelManager = GameObject.Find("LevelManager");
        Activate();
    }

    protected virtual void Activate() { }

    protected int Left() {
        if (index == 0 || index == 4) {
            return -1;
        } else {
            return index - 1;
        }
    }

    protected int Right() {
        if (index == 3 || index == 7) {
            return -1;
        } else {
            return index + 1;
        }
    }

    protected int Behind() {
        if (index < 4) {
            return index + 4;
        } else {
            return -1;
        }
    }

    protected int Front() {
        if (index < 4) {
            return -1;
        } else {
            return index - 4;
        }
    }

    protected override void Dead() {
        base.Dead();
        Destroyed();
        GetComponentInParent<LevelManager>().ArtifactDestroyed(index);
    }

    protected virtual void Destroyed() { }
}
