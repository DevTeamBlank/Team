using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Inst { get; private set; }

    [SerializeField] int startHp_ = 5;
    [SerializeField] int startChoice_ = 1;

    public int hp;
    public int choice;

    void Awake() {
        Inst = this;
    }
    
    public void StartGame() {
        hp = startHp_;
        HPBar.Inst.UpdateHP();
        choice = startChoice_;
    }

    public void Load(Save save) {
        hp = save.hp;
        choice = save.choice;
    }

    public void Damaged() {
        hp--;
        HPBar.Inst.UpdateHP();
        if (hp <= 0) {
            GameManager.Inst.GameOver();
        }
    }

    public void Heal() {
        if (hp < startHp_) {
            hp++;
            HPBar.Inst.UpdateHP();
        }
    }

    public int GetHp() {
        return hp;
    }

    public int GetChoice() {
        return choice;
    }

    public void SetChoice(int val) {
        choice = val;
    }
}
