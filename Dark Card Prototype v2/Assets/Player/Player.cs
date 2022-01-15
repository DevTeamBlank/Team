using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Card;

public class Player : MonoBehaviour {

    public static Player Inst { get; private set; }
   
    void Awake() {
        Inst = this;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            GainStrength(1);
        }
        if (Input.GetKey(KeyCode.W)) {
            GainStrength(1);
        }
    }

    public int maxHealth;
    [SerializeField] int health;
    public int armor;

    [SerializeField] int vulnerable;
    [SerializeField] int weakness;
    [SerializeField] bool barricade;

    [SerializeField] int strength;
    [SerializeField] int dexterity;

    void Start() {
        health = maxHealth;
        Reset();
    }

    public void Reset() {
        vulnerable = 0;
        weakness = 0;
        barricade = false;

        strength = 0;
        dexterity = 0;
    }

    public bool IsVulnerable() {
        return 0 < vulnerable;
    }
    public bool IsWeakness() {
        return 0 < weakness;
    }

    public bool IsBarricade() {
        return barricade;
    }

    public void ApplyVulnerable(int duration) {
        vulnerable += duration;
    }
    public void ApplyWeakness(int duration) {
        weakness += duration;
    }
    public void ApplyBarricade() {
        barricade = true;
    }

    public void GainStrength(int value) {
        strength += value;
    }

    public int ApplyDamage(int value) {
        int ret = value + strength;
        if (IsWeakness()) {
            ret = (int)(ret * 0.75f);
        }
        return ret;
    }

    public void GainDexterity(int value) {
        dexterity += value;
    }

    public void GainArmor(int value) {
        armor += (value + dexterity);
    }

    public void TakeDamage(int value) {

    }

    public void HealHealth(int value) {
        int temp = health + value;
        if (temp < maxHealth) {
            health = temp;
        } else {
            temp = maxHealth;
        }
    }
    public void LossHealth(int value) {
        int temp = health - value;
        if (0 < temp) {
            health = temp;
        } else {
            Dead();
        }
    }

    void Dead() {
        // TODO
        // Restart the game
    }
}
