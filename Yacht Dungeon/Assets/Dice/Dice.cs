using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    [SerializeField] bool isFixed;
    [SerializeField] int num;
    [SerializeField] int leftReroll;

    public int index_;
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

        CheckReroll();
    }

    public void RollDice() {
        if (!isFixed) {
            RerollDice();
        }
    }

    protected virtual void RerollDice() {
        Random.InitState(GameManager.Seed + leftReroll * 13 + RoundManager.Inst.currentRound * 17);
        int random = Random.Range(0, 6);
        num = faces_[random];
        GetComponent<SpriteRenderer>().sprite = sprites_[random];
        leftReroll--;
        CheckReroll();
    }

    void CheckReroll() {
        if (leftReroll <= 0) {
            isFixed = true;
            FixDice();
        }
    }

    public void ToggleFixDice() {
        if (isFixed) {
            UnfixDice();
        } else {
            FixDice();
        }
    }

    void FixDice() {
        isFixed = true;
        transform.Find("FixSquare").GetComponent<SpriteRenderer>().enabled = true;
    }

    void UnfixDice() {
        isFixed = false;
        transform.Find("FixSquare").GetComponent<SpriteRenderer>().enabled = false;
    }

    public int GetNumber() {
        return num;
    }
}
