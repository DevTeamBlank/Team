using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public static TurnManager Inst { get; private set; }

    [SerializeField] int turn;

    void Awake() {
        Inst = this;
    }

    void Start() {
        
    }

    public void ResetEntityManager() { // DungeonManager∞° »£√‚

    }

    public void PlayerTurnStart() {
        Player.Inst.TurnStartGainEnergy();
        // CardManager.Inst.Draw(5);
        // CardManager.Inst.CanPlay();
    }
    
    public void PlayerTurnEnd() {
        Player.Inst.TurnEndLossArmor();
        // CardManager.Inst.DiscardAll();
        // CardManager.Inst.Nothing();
    }
}
