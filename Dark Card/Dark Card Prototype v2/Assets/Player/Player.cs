using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

    public static Player Inst { get; private set; }
   
    void Awake() {
        Inst = this;
        FindUI();
    }

    void Start() {

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
        if (Input.GetKeyDown(KeyCode.D)) {
            GainEnergy(1);
        }
    }

    public int maxHealth = 60;
    [SerializeField] int health;
    [SerializeField] int armor;

    public int GetArmor() {
        return armor;
    }
    public int GetStrength() {
        return strength;
    }

    [SerializeField] int vulnerable;
    [SerializeField] int weakness;
    [SerializeField] bool barricade;

    [SerializeField] int strength;
    [SerializeField] int dexterity;

    [SerializeField] int baseEnergy = 3;
    public int turnEnergy = 3;
    public int energy;

    public void MaxHeal() {
        HealHealth(maxHealth);
    }

    public void PlayerSetting() {
        vulnerable = 0;
        weakness = 0;
        barricade = false;

        strength = 0;
        dexterity = 0;

        turnEnergy = baseEnergy;

        
        EnergyUpdate();
        HealthUpdate();
        ArmorUpdate();
        StrengthUpdate();
        DexterityUpdate();
        VulnerableUpdate();
        WeaknessUpdate();
        BarricadeUpdate();
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

    public void GainStrength(int value) {
        strength += value;
        StrengthUpdate();
    }

    public int ApplyDamage(int value) {
        int ret = value + strength;
        if (IsWeakness()) {
            ret = (int)(ret * 0.75f);
        }
        return ret;
    }

    public int ApplyArmor(int value) {
        return value + dexterity;
    }

    public void GainDexterity(int value) {
        dexterity += value;
        DexterityUpdate();
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
        if (temp <= maxHealth) {
            health = temp;
        } else {
            health = maxHealth;
        }
        HealthUpdate();
    }

    public void LossHealth(int value) {
        if (value <= 0) return;

        int temp = health - value;
        if (0 < temp) {
            health = temp;
            HealthUpdate();
        } else {
            health = 0;
            HealthUpdate();
            Dead();
        }
    }

    public void GainEnergy(int value) {
        energy += value;
        EnergyUpdate();
    }

    public int UseAllEnergy() {
        int ret = energy;
        energy = 0;
        EnergyUpdate();
        return ret;
    }

    public void UseEnergy(int value) {
        if (value <= energy) {
            energy -= value;
            EnergyUpdate();
        } else {
            Debug.Log("Unvalid value.");
        }
    }

    public void TurnStart() {
        TurnStartLossArmor();
        TurnStartGainEnergy();
        DecreaseVulnerable();
    }

    void TurnStartGainEnergy() {
        energy = turnEnergy;
        EnergyUpdate();
    }

    public void TurnEnd() {        
        DecreaseWeakness();
    }

    void TurnStartLossArmor() {
        if (!IsBarricade()) LossArmor(armor);
    }

    void FindUI() {
        energyUI = transform.Find("EnergyUI").GetComponent<TextMeshPro>();
        healthUI = transform.Find("HealthUI").GetComponent<TextMeshPro>();
        armorUI = transform.Find("ArmorUI").GetComponent<TextMeshPro>();
        strengthUI = transform.Find("StrengthUI").GetComponent<TextMeshPro>();
        dexterityUI = transform.Find("DexterityUI").GetComponent<TextMeshPro>();
        vulnerableUI = transform.Find("VulnerableUI").GetComponent<TextMeshPro>();
        weaknessUI = transform.Find("WeaknessUI").GetComponent<TextMeshPro>();
    }

    TextMeshPro energyUI;
    void EnergyUpdate() {        
        energyUI.text = "E: " + energy + " / " + turnEnergy;
    }

    TextMeshPro healthUI;
    void HealthUpdate() {        
        healthUI.text = health + " / " + maxHealth;
    }

    TextMeshPro armorUI;
    void ArmorUpdate() {
        armorUI.text = armor.ToString();
    }

    TextMeshPro strengthUI;
    void StrengthUpdate() {
        strengthUI.text = strength.ToString();
    }

    TextMeshPro dexterityUI;
    void DexterityUpdate() {
        dexterityUI.text = dexterity.ToString();
    }

    TextMeshPro vulnerableUI;
    void VulnerableUpdate() {
        vulnerableUI.text = vulnerable.ToString();
    }

    TextMeshPro weaknessUI;
    void WeaknessUpdate() {
        weaknessUI.text = weakness.ToString();
    }
    void BarricadeUpdate(bool barricade = false) {
        transform.Find("BarricadeUI").GetComponent<SpriteRenderer>().enabled = barricade;
    }


    void Dead() {
        LossArmor(armor);
        Debug.Log("Dead");
        // TODO
        // Restart the game
    }
}
