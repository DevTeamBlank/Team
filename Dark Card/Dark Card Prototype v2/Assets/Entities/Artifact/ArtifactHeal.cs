using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactHeal : Artifact {

    [SerializeField] int healValue;

    protected override void ArtifactTurnStart() {
        LevelManager.Status[] statuses = levelManager.GetComponent<LevelManager>().GetStatuses();
        GameObject[] enemies = levelManager.GetComponent<LevelManager>().entities;

        float minHealthPercent = 1f;
        int index = -1;
        for (int i = 0; i < statuses.Length; i++) {
            if (statuses[i] == LevelManager.Status.aliveEnemy) {
                int maxHealth = enemies[i].GetComponent<Entity>().maxHealth;
                int health = enemies[i].GetComponent<Entity>().GetHealth();
                float percent = health / maxHealth;
                if (percent <= minHealthPercent) {
                    index = i;
                    minHealthPercent = percent;
                }
            }
        }

        GameObject target = enemies[index];
        target.GetComponent<Entity>().HealHealth(healValue);
    }

}
