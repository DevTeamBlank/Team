using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private GameObject player;
    public GameObject[] enemies;

    private int currentTurn; // 0: player;

    void Start() {
        player = GameObject.Find("Player");
        currentTurn = 0;
    }

    void Update() {

    }

    public void BattleStart() {
        player.GetComponent<Status>().BattleStart();
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<Status>().BattleStart();
        }
    }

    public void BattleEnd(bool clear) {
        if (clear) {
            // next level
        } else {
            // player dead
        }
    }

    public void TurnEnd() {
        switch (currentTurn) {
            case 0: // Player Turn End
                player.GetComponent<Status>().TurnEnd();
                break;
        }
    }
}
