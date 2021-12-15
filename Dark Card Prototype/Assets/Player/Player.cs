using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string nickName;

    public int maxHealth;
    private int health;

    private int gold;


    // Start is called before the first frame update
    void Start() {
        DontDestroyOnLoad(gameObject);
        canRevive = false;
        gold = 0;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {

    }

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
            Dead();
        } else {
            health = temp;
        }
    }

    private bool canRevive;

    public void Dead() {
        if (canRevive) {

        }
        health = 0;
        // GameObject battleManager = GameObject.FindGameObjectWithTag("BattleManager");
    }

    public void SetGold(int value) {
        gold = value;
    }

    public void EarnGold(int reward) {
        gold += reward;
    }

    public bool PayGold(int price) {
        int temp = gold - price;
        if (temp < 0) {
            return false;
        } else {
            gold = temp;
            return true;
        }
    }
}
