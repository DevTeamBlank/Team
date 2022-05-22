using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

    public static HPBar Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    [SerializeField] Sprite fullSprite_;
    [SerializeField] Sprite emptySprite_;

    [SerializeField] GameObject[] hpBars_ = new GameObject[5];

    public void UpdateHP() {
        int hp = Player.Inst.hp;
        for (int i = 0; i < hp; i++) {
            hpBars_[i].GetComponent<SpriteRenderer>().sprite = fullSprite_;
        }
        for (int i = hp; i < 5; i++) {
            hpBars_[i].GetComponent<SpriteRenderer>().sprite = emptySprite_;
        }
    }
}
