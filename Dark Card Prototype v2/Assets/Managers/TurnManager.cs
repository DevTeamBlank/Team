using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public static TurnManager Inst { get; private set; }

    [SerializeField] int turn;
    public bool isMyTurn;

    GameObject levelManager;

    void Awake() {
        Inst = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isMyTurn) {
                PlayerTurnEnd();
            }
        }
    }

    public void TurnSetting() {
        // TODO
        // Show UI
        levelManager = GameObject.Find("LevelManager");
        turn = 0;
        isMyTurn = false;
        PlayerTurnStart();
    }

    public void PlayerTurnStart() {
        isMyTurn = true;
        turn++;
        Player.Inst.TurnStart();
        CardManager.Inst.DrawCards(5);
        CardManager.Inst.SetCardPlayStatus();
    }
    
    void PlayerTurnEnd() {
        CardManager.Inst.SetCardPlayStatus();
        Player.Inst.TurnEnd();
        CardManager.Inst.TurnEnd();
        isMyTurn = false;
        levelManager.GetComponent<LevelManager>().EnemyTurnStart();
    }

    public void LevelCleared() {
        // TODO
        // Hide UI
    }
}
