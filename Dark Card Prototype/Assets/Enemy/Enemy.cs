using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public enum EnemyType { // 0: monster, 1: elite, 2: boss, 3: fianlBoss
        monster,
        elite,
        boss,
        finalBoss
    }

    public int ID;
    public string nomenclature;

    public int level;
    public int maxHealth;
    public int basicArmor;
    protected int health;
    protected int armor;
    bool isAlive = true;

    public Reward reward;

    public void GetDamage(int finalDamage) {
        health -= finalDamage;
    }
}
