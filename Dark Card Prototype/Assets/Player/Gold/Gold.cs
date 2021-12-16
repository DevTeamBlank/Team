using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour {

    public int gold;
    public TextMeshProUGUI text;

    void Start() {
        gold = 0;
        UpdateUI();
    }

    public void UpdateUI() {
        text.GetComponent<TextMeshProUGUI>().text = gold.ToString();
    }

    public int GetGold() {
        return gold;
    }

    public void SetGold(int value) {
        gold = value;
        UpdateUI();
    }
    
    public void EarnGold(int reward) {
        gold += reward;
        UpdateUI();
    }

    public bool PayGold(int price) {
        int temp = gold - price;
        if (temp < 0) {
            return false;
        } else {
            gold = temp;
            UpdateUI();
            return true;
        }
    }
}
