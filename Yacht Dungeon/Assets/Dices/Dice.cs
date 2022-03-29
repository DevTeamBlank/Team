using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    [SerializeField] bool isFixed_;
    [SerializeField] int num_;
    [SerializeField] int leftReroll_;

    public int ID;
    public string nomenclature;
    public DiceRarity rarity;
    public string description;

    [SerializeField] int[] faces = new int[6];
    [SerializeField] Sprite[] sprites = new Sprite[6];
    [SerializeField] int reroll;

    public enum DiceRarity {
        Basic,
        Common,
        Uncommon,
        Rare
    }


    private void Start() {
        SetDice();
    }

    public void SetDice() {
        isFixed_ = false;
        num_ = faces[0];
        leftReroll_ = reroll;

        fixSquare = transform.Find("FixSquare").GetComponent<SpriteRenderer>();
        fixSquare.enabled = false;
    }

    public void RollDice() {
        if (!isFixed_) {
            RerollDice();
        }
    }

    void RerollDice() {
        int random = Random.Range(0, 6);
        num_ = faces[random];
        GetComponent<SpriteRenderer>().sprite = sprites[random];
        leftReroll_--;
    }

    void CheckReroll() {
        if (leftReroll_ <= 0) {
            isFixed_ = true;
            FixDice();
        }
    }

    SpriteRenderer fixSquare;

    public void ToggleFixDice() {
        if (isFixed_) {
            UnfixDice();
        } else {
            FixDice();
        }
    }

    void FixDice() {
        isFixed_ = true;
        fixSquare.enabled = true;
    }

    void UnfixDice() {
        isFixed_ = false;
        fixSquare.enabled = false;
    }

    public void FixDiceAs(int number, Sprite sprite) {
        num_ = number;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public int GetNumber() {
        return num_;
    }
}
