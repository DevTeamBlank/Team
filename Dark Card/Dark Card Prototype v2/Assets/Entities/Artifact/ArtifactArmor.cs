using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactArmor : Artifact {

    [SerializeField] int armorValue;

    protected override void ArtifactTurnStart() {
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Behind()];
        if (status == LevelManager.Status.aliveEnemy) {
            GameObject behind = levelManager.GetComponent<LevelManager>().entities[Behind()];
            behind.GetComponent<Entity>().GainArmor(armorValue);
        }
    }
}
