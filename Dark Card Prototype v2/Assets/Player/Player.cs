using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Inst { get; private set; }
   
    void Awake() {
        Inst = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            GainStrength(1);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            GainDexterity(1);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            GainArmor(3);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            TakeDamage(5);
        }
    }

    public int maxHealth = 60;
    [SerializeField] int health;
    [SerializeField] int armor;

    [SerializeField] int vulnerable;
    [SerializeField] int weakness;
    [SerializeField] bool barricade;

    [SerializeField] int strength;
    [SerializeField] int dexterity;

    public int baseEnergy = 3;
    public int energy;

    void Start() {
        Reset();
        BattleStart();
    }

    public void Reset() {
        health = maxHealth;

        vulnerable = 0;
        weakness = 0;
        barricade = false;

        strength = 0;
        dexterity = 0;
    }

    public virtual void BattleStart() { }

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

    public void LossArmor(int value) {
        armor -= value;
        if (armor < 0) armor = 0;
    }

    public void TakeDamage(int value) {
        int temp = value;
        if (IsVulnerable()) {
            temp = (int)(temp * 1.5f);
        }
        if (temp <= armor) {
            LossArmor(temp);
        } else {
            LossHealth(temp - armor);
            LossArmor(armor);
        }       
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
        if (value <= 0) return;

        int temp = health - value;
        if (0 < temp) {
            health = temp;
        } else {
            Dead();
        }
    }

    public void GainEnergy(int value) {
        energy += value;
    }

    public int ConsumeAllEnergy() {
        int ret = energy;
        energy = 0;
        return ret;
    }

    public bool ConsumeEnergy(int value) {
        if (value < energy) {
            energy -= value;
            return true;
        } else {
            return false;
        }
    }

    public void TurnStartGainEnergy() {
        energy = baseEnergy;
    }

    public void TurnEndLossArmor() {
        if (!IsBarricade()) LossArmor(armor);
    }

    void Dead() {
        health = 0;
        Debug.Log("Dead");
        // TODO
        // Restart the game
    }
}
