using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGremlin : Enemy {
   
    protected override void DecidePattern() {
        GameObject levelManager = GameObject.Find("LevelManager");
        int remainingEnemies = levelManager.GetComponent<LevelManager>().GetRemainingEnemies();
        currPattern = (remainingEnemies > 1) ? 0 : 1;
        UpdateIntent(intents[currPattern]);
        UpdateDamage(damages[currPattern]);
    }

    public override void Patterns(int index) {
        switch (index) {
            case 0:
                Pattern0();
                break;
            case 1:
                Pattern1();
                break;
        }
    }

    [SerializeField] int patternArmor;

    public void Pattern0() {
        GameObject levelManager = GameObject.Find("LevelManager");
        LevelManager.Status[] statuses = levelManager.GetComponent<LevelManager>().GetStatuses();
        List<int> list = new List<int>();
        for (int i = 0; i < statuses.Length; i++) {
            if (statuses[i] == LevelManager.Status.aliveEnemy) {
                list.Add(i);
            }
        }

        if (list.Count == 1 && list[0] == index) {
            GainArmor(patternArmor);
            return;
        }

        list.Remove(index);
        int random = Random.Range(0, list.Count);
        levelManager.GetComponent<LevelManager>().entities[list[random]].GetComponent<Entity>().GainArmor(patternArmor);

    }

    public void Pattern1() {
        int damage = ApplyDamage(damages[1]);
        Player.Inst.TakeDamage(damage);
    }

}
