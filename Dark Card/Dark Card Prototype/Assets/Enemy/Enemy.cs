using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int EnemyType; // 0: monster, 1: elite, 2: boss, 3: fianlBoss

    public int ID;
    public string nomenclature;

    public int maxHealth;
    protected int health;

    public Reward reward;
    public void Heal(int heal) {
        int temp = health + heal;
        if (maxHealth < temp) {
            health = maxHealth;
        } else {
            health = temp;
        }
    }
    public void Damaged(int finalDamage) {
        int temp = health - finalDamage;
        if (temp <= 0) {
            health = 0;
        } else {
            health = temp;
        }
    }
}
