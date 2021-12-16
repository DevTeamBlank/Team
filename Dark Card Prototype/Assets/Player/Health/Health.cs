using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour {

    public int maxHealth;
    private int health;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start() {
        health = maxHealth;

        UpdateUI();
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateUI() {
        text.GetComponent<TextMeshProUGUI>().text = health.ToString() + "/" + maxHealth.ToString();
    }
    public void Heal(int heal) {
        int temp = health + heal;
        if (maxHealth < temp) {
            health = maxHealth;
        } else {
            health = temp;
        }
        UpdateUI();
    }

    public void Damaged(int finalDamage) {
        int temp = health - finalDamage;
        if (temp <= 0) {
            Dead();
        } else {
            health = temp;
            UpdateUI();
        }
    }

    public void Dead() {
        health = 0;
        UpdateUI();
        // GameObject battleManager = GameObject.FindGameObjectWithTag("BattleManager");
    }
}
