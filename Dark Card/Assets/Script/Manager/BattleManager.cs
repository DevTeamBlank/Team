using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public static BattleManager Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    void Update() {
        Dequeue();
    }

    List<Action> queue;

    public void Enqueue(Action a) {
        queue.Add(a);
    }

    public void Dequeue() {
        if (queue.Count == 0) return;

        Action action = queue[0];
        switch (action.type) {
            case Action.Type.Damage:
                // TODO
                break;
            // TODO
        }
        queue.RemoveAt(0);
    }

    void Clear() {
        queue = new List<Action>();
    }

    Subject playerTakeDamage;

    Subject playerPlayCard;
    Subject playerPlayAttackCard;
    Subject playerPlaySkillCard;
    Subject playerDrawCard;
    Subject playerDiscardCard;
    Subject playerExhaustCard;

    Subject playerShuffleDeck;

    Subject playerStartTurn;
    Subject playerEndTurn;

    Subject playerGetBuff;
    Subject playerGetDebuff;


}
