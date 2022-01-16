using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card02 : Card { // Attack_R

    [SerializeField] int damage;
    protected override void Play() {
        if (IsPlayble()) {
            UseEnergy();
            int applyDamage = Player.Inst.ApplyDamage(damage);
            GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage);
            // DiscardPile�� �̵�
        } else {
            // ī�� ���ڸ���
        }
    }
}

