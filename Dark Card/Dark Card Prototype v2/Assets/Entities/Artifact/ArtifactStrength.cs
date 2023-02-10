using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactStrength : Artifact {

    [SerializeField] int strengthValue;

    protected override void Activate() {
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Left()];
        if (status == LevelManager.Status.aliveEnemy) {
            GameObject left = levelManager.GetComponent<LevelManager>().entities[Left()];
            left.GetComponent<Entity>().GainStrength(strengthValue);
        }
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Right()];
        if (status == LevelManager.Status.aliveEnemy) {
            GameObject right = levelManager.GetComponent<LevelManager>().entities[Right()];
            right.GetComponent<Entity>().GainStrength(strengthValue);
        }
    }

    protected override void Destroyed() {
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Left()];
        if (status == LevelManager.Status.aliveEnemy || status == LevelManager.Status.deadEnemy) {
            GameObject left = levelManager.GetComponent<LevelManager>().entities[Left()];
            left.GetComponent<Entity>().GainStrength(-1 * strengthValue);
        }
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Right()];
        if (status == LevelManager.Status.aliveEnemy || status == LevelManager.Status.deadEnemy) {
            GameObject right = levelManager.GetComponent<LevelManager>().entities[Right()];
            right.GetComponent<Entity>().GainStrength(-1 * strengthValue);
        }
    }

}
