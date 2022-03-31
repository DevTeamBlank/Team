using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    [SerializeField] bool isFixed;
    [SerializeField] int num;
    [SerializeField] int leftReroll;

    public int ID_;
    public string nomenclature_;
    public DiceRarity rarity_;
    public string description_;

    [SerializeField] int[] faces_ = new int[6];
    [SerializeField] Sprite[] sprites_ = new Sprite[6];
    [SerializeField] int reroll_;

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
        isFixed = false;
        num = faces_[0];
        leftReroll = reroll_;

        fixSquare = transform.Find("FixSquare").GetComponent<SpriteRenderer>();
        fixSquare.enabled = false;
    }

    public void RollDice() {
        if (!isFixed) {
            RerollDice();
        }
    }

    void RerollDice() {
        Random.InitState(GameManager.Seed + leftReroll * 13 + RoundManager.Inst.currentRound * 17);
        int random = Random.Range(0, 6);
        num = faces_[random];
        GetComponent<SpriteRenderer>().sprite = sprites_[random];
        leftReroll--;
    }

    void CheckReroll() {
        if (leftReroll <= 0) {
            isFixed = true;
            FixDice();
        }
    }

    SpriteRenderer fixSquare;

    public void ToggleFixDice() {
        if (isFixed) {
            UnfixDice();
        } else {
            FixDice();
        }
    }

    void FixDice() {
        isFixed = true;
        fixSquare.enabled = true;
    }

    void UnfixDice() {
        isFixed = false;
        fixSquare.enabled = false;
    }

    public void FixDiceAs(int number, Sprite sprite) {
        num = number;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public int GetNumber() {
        return num;
    }
}
