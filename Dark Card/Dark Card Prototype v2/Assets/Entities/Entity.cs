using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Entity : MonoBehaviour { // Enemies, Objects

    public string nomenclature;
    public int maxHealth;
    public int index;

    [Header("These are serialized fields")]
    [SerializeField] int health;

    public int GetHealth() {
        return health;
    }

    [SerializeField] int armor;

    [SerializeField] int vulnerable;
    [SerializeField] int weakness;
    [SerializeField] bool barricade;

    [SerializeField] int strength;

    [SerializeField] bool isAlive = true;

    public void Setting() {
        health = maxHealth;

        vulnerable = 0;
        weakness = 0;
        barricade = false;

        strength = 0;

        FindUI();
        HealthUpdate();
        ArmorUpdate();
        StrengthUpdate();
        VulnerableUpdate();
        WeaknessUpdate();
        BarricadeUpdate();
    }

    public virtual void BattleStart() { }

    public virtual void TurnStart() {
        TurnStartLossArmor();
        DecreaseVulnerable();
    }
    public virtual void TurnEnd() {        
        DecreaseWeakness();        
    }

    protected void DecreaseVulnerable() {
        if (IsVulnerable()) {
            vulnerable--;
            VulnerableUpdate();
        }
    }

    protected void DecreaseWeakness() {
        if (IsWeakness()) {
            weakness--;
            WeaknessUpdate();
        }
    }

    public void TurnStartLossArmor() {
        if (!IsBarricade()) LossArmor(armor);
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
        VulnerableUpdate();
    }
    public void ApplyWeakness(int duration) {
        weakness += duration;
        WeaknessUpdate();
    }
    public void ApplyBarricade(bool barricade) {
        this.barricade = barricade;
        BarricadeUpdate(barricade);
    }

    void BarricadeUpdate(bool barricade = false) {
        transform.Find("BarricadeUI").GetComponent<SpriteRenderer>().enabled = barricade;
    }

    public void GainStrength(int value) {
        strength += value;
        StrengthUpdate();
    }

    public void GainArmor(int value) {
        armor += value;
        ArmorUpdate();
    }

    public void LossArmor(int value) {
        armor -= value;
        if (armor < 0) armor = 0;
        ArmorUpdate();
    }

    public virtual void TakeDamage(int value) {
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
        if (temp <= maxHealth) {
            health = temp;
        } else {
            health = maxHealth;
        }
        HealthUpdate();
    }

    public void LossHealth(int value) {
        if (value == 0) return;

        int temp = health - value;
        if (0 < temp) {
            health = temp;
        } else {
            Dead();
        }

        HealthUpdate();
    }

    void FindUI() {
        healthUI = transform.Find("HealthUI").GetComponent<TextMeshPro>();
        armorUI = transform.Find("ArmorUI").GetComponent<TextMeshPro>();
        strengthUI = transform.Find("StrengthUI").GetComponent<TextMeshPro>();
        vulnerableUI = transform.Find("VulnerableUI").GetComponent<TextMeshPro>();
        weaknessUI = transform.Find("WeaknessUI").GetComponent<TextMeshPro>();
    }

    TextMeshPro healthUI;
    protected void HealthUpdate() {        
        if (isAlive) {
            healthUI.text = health.ToString();
        } else {
            healthUI.text = "Dead";
        }
    }

    TextMeshPro armorUI;
    void ArmorUpdate() {
        armorUI.text = armor.ToString();
    }

    TextMeshPro strengthUI;
    void StrengthUpdate() {
        strengthUI.text = strength.ToString();
    }

    TextMeshPro vulnerableUI;
    void VulnerableUpdate() {
        vulnerableUI.text = vulnerable.ToString();
    }

    TextMeshPro weaknessUI;
    void WeaknessUpdate() {
        weaknessUI.text = weakness.ToString();
    }

    protected virtual void Dead() {
        isAlive = false;
    }
}
