using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactBarricade : Artifact {

    protected override void Activate() {
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Left()];
        if (status == LevelManager.Status.aliveEnemy) {
            GameObject left = levelManager.GetComponent<LevelManager>().entities[Left()];
            left.GetComponent<Entity>().ApplyBarricade(true);
        }
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Right()];
        if (status == LevelManager.Status.aliveEnemy) {
            GameObject right = levelManager.GetComponent<LevelManager>().entities[Right()];
            right.GetComponent<Entity>().ApplyBarricade(true);
        }
    }

    protected override void Destroyed() {
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Left()];
        if (status == LevelManager.Status.aliveEnemy || status == LevelManager.Status.deadEnemy) {
            GameObject left = levelManager.GetComponent<LevelManager>().entities[Left()];
            left.GetComponent<Entity>().ApplyBarricade(false);
        }
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Right()];
        if (status == LevelManager.Status.aliveEnemy || status == LevelManager.Status.deadEnemy) {
            GameObject right = levelManager.GetComponent<LevelManager>().entities[Right()];
            right.GetComponent<Entity>().ApplyBarricade(false);
        }
    }

}
