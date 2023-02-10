using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public int strength;
    public int dexterity;
    public int armor;
    public bool barricade;
    public int weakness;
    public int vulnerable;
    public int regeneration;

    private int turn;

    void Start() {
        
    }

    public void BattleStart() {
        turn = 0;
    }

    public void TurnStart() {
        turn++;
        // TODO
        // GetComponent<Deck>().DrawCard(5);
        // GetComponent<Card>().canPlayCard = false;
    }

    public void DamageGive(int value, GameObject target) {
        int damage = value += strength;
        if (0 < weakness) {
            damage = (int)(damage * 0.75f);
        }
    }

    public void DamageTake(int value) {
        int damage = value;
        if (0 < vulnerable) {
            damage = (int)(damage * 1.5f);
        }
        
        if (damage <= armor) {
            ArmorRemove(damage);
        } else {
            damage -= armor;
            ArmorRemove(armor);
            GetComponent<Health>().DamageTake(damage);
        }
    }

    public void ArmorGain(int value) {
        armor += value + dexterity;
        UpdateUI();
    }

    void ArmorRemove(int value) {
        armor -= value;
        if (armor < 0) {
            Debug.Log("Unexpected");
        }
        UpdateUI();
    }

    public void TurnEnd() {
        // GetComponent<Card>().canPlayCard = false;
        if (!barricade) {
            ArmorRemove(armor);
        }
        if (vulnerable > 0) {
            vulnerable--;
        }
        if (weakness > 0) {
            weakness--;
        }
        // GetComponent<Card>().DiscardAllHand();
        UpdateUI();
    }

    void UpdateUI() {
        // TODO
        // vulnerable, weakness, armor etc.
    }
}

