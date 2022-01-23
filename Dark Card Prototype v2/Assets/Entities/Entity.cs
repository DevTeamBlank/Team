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

    public int index;

    void Start() {

    }

    public virtual void BattleStart() { }


    public void Setting() {
        health = maxHealth;

        vulnerable = 0;
        weakness = 0;
        barricade = false;

        strength = 0;

        GetComponent<Enemy>().BattleStart();
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

    public int ApplyDamage(int value) {
        int ret = value + strength;
        if (IsWeakness()) {
            ret = (int)(ret * 0.75f);
        }
        return ret;
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

    public void GainArmor(int value) {
        armor += value;
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
