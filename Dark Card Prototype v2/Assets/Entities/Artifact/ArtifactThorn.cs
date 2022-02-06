using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtifactThorn : Artifact {

    [SerializeField] int armorValue;
    [SerializeField] int thorns;

    protected override void Activate() {
        UpdateThorns();
    }

    protected override void ArtifactTurnStart() {
        status = levelManager.GetComponent<LevelManager>().GetStatuses()[Behind()];
        if (status == LevelManager.Status.aliveEnemy) {
            GameObject behind = levelManager.GetComponent<LevelManager>().entities[Behind()];
            behind.GetComponent<Entity>().GainArmor(armorValue);
        }
    }

    public override void TakeDamage(int value) {
        base.TakeDamage(value);
        Player.Inst.TakeDamage(thorns);
    }

    void UpdateThorns() {
        transform.Find("ThornsUI").GetComponent<TextMeshPro>().text = thorns.ToString();
    }

}
