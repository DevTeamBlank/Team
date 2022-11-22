using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int[] roundHp_ = new int[15];
    public int[] roundOffset_ = new int[15];

    public static EnemyManager Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    public int MeteorHp(int round) {
        return roundHp_[round];
    }

    public int Enemy1Hp(int round) {
        return roundHp_[round] + roundOffset_[round];
    }

    public int Enemy2Hp(int round) {
        return roundHp_[round] - roundOffset_[round];
    }

}
