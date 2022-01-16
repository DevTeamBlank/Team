using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour { // Enemies, Objects

    public string nomenclature;

    public int maxHealth;
    [SerializeField] int health;
    [SerializeField] int armor;

    [SerializeField] int vulnerable;
    [SerializeField] int weakness;
    [SerializeField] bool barricade;

    [SerializeField] int strength;
    [SerializeField] int dexterity;

    public int index;

    void Start() {
        Reset();
        BattleStart();
    }

    public virtual void BattleStart() { }

    public virtual void Pattern() { } // 행동 양식

    public void Reset() {
        health = maxHealth;

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
    public void GainDexterity(int value) {
        dexterity += value;
    }

    public void GainArmor(int value) {
        armor += (value + dexterity);
    }

    public void LossArmor(int value) {
        armor -= value;
        if (armor < 0) armor = 0;
    }

    public void TakeDamage(int value) {
        int temp = value;
        if (IsVulnerable()) {
            temp = (int)(temp * 1.5f);
        }
        int temp2 = temp - armor;
        LossArmor(armor);
        LossHealth(temp2);
    }

    public void LossHealth(int value) {
        if (value == 0) return;

        int temp = health - value;
        if (0 < temp) {
            health = temp;
        } else {
            Dead();
        }
    }

    protected virtual void Dead() { }
}
