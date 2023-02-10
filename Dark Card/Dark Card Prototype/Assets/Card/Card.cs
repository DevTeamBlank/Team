using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public int ID;
    public string nomenclature;

    public int cost; // -1: Unusable
    public int cardType; // 0: Attack, 1: Skill, 2: Power (Unused), 3: Disturb

    public bool hasTarget;
    public int validTargetType;
    /* 0: NaN, 1: Player, 2: Enemy, 4: Object
     * Most of cards are 0, 1, 6 */
    public void ChangeCost(int value) { // (e.g. Snecko's Eye)
        cost = value;
        ChangeCostUI();
    }

    public void IncreaseCost(int value) { // (e.g. Corruption)
        cost += value;
        ChangeCostUI();
    }

    private void ChangeCostUI() {
        // TODO
    }

    protected virtual void Played(GameObject target) {
        // GameObject battleManager = GameObject.FindGameObjectWithTag("BattleManager");
    }

}
