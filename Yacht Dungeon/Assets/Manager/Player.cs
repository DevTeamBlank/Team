using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Inst { get; private set; }

    [SerializeField] int startHp_;
    [SerializeField] int startChoice_;

    public int hp;
    public int choice;

    void Awake() {
        Inst = this;
    }

    // Update is called once per frame
    void Update() {

    }
    
    public void StartGame() {
        hp = startHp_;
        choice = startChoice_;
    }

    public void Load(Save save) {
        hp = save.hp;
        choice = save.choice;
    }

    public void Damaged() {
        hp--;
        if (hp <= 0) {
            GameManager.Inst.GameOver();
        }
    }
}
