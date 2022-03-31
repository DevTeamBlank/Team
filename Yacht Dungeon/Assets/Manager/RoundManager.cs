using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public static RoundManager Inst { get; private set; }

    public int currentRound;

    public enum Phase {
        RoundStart,
        RollSet0,
        RollSet1,
        RollSet2,
        DealDamage,
        Reward,
    }

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        currentRound = 0;
    }

    [SerializeField] GameObject enemy0;
    [SerializeField] GameObject chest;
    [SerializeField] GameObject enemy1;

    public void NextRound() {
        currentRound++;
        GameManager.Inst.SaveGame();
    }

    public void Load(Save save) {
        currentRound = save.clearedRound;
    }

    
}
