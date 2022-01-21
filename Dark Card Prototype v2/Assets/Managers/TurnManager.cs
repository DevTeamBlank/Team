using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public static TurnManager Inst { get; private set; }

    [SerializeField] int turn;
    public bool isMyTurn;

    void Awake() {
        Inst = this;
    }

    void Start() {

    }

    public void TurnSetting() {
        // TODO
        // Show UI
        turn = 0;
        isMyTurn = false;
        PlayerTurnStart();
    }

    void PlayerTurnStart() {
        isMyTurn = true;
        turn++;
        Player.Inst.TurnStartGainEnergy();
        CardManager.Inst.DrawCards(5);
        CardManager.Inst.SetCardPlayStatus();
    }
    
    void PlayerTurnEnd() {
        CardManager.Inst.SetCardPlayStatus();
        Player.Inst.TurnEndLossArmor();
        CardManager.Inst.DiscardAll();
        isMyTurn = false;
    }

    public void LevelCleared() {
        // TODO
        // Hide UI
    }
}
