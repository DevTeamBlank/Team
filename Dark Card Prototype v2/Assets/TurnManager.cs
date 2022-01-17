using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public static TurnManager Inst { get; private set; }

    [SerializeField] int turn;
    public bool isLoading;
    public bool isMyTurn;

    void Awake() {
        Inst = this;
    }

    void Start() {
        
    }

    public void ResetLevelManager() { // DungeonManager∞° »£√‚

    }

    public void PlayerTurnStart() {
        isMyTurn = true;
        Player.Inst.TurnStartGainEnergy();
        CardManager.Inst.DrawCards(5);
        CardManager.Inst.SetCardPlayStatus();
    }
    
    public void PlayerTurnEnd() {
        CardManager.Inst.SetCardPlayStatus();
        Player.Inst.TurnEndLossArmor();
        // CardManager.Inst.DiscardAll();
        isMyTurn = false;
    }


}
