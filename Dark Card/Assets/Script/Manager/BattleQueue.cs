using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleQueue {

    List<Action> queue;

    BattleQueue() {
        queue = new List<Action>();
    }

    void Enqueue(Action action) {
        queue.Add(action);
    }

    void Dequeue(Action action) {

    }

    void Clear() {
        queue = new List<Action>();
    }

}
