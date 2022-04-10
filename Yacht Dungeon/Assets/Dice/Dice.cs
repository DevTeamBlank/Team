using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    [SerializeField] protected bool isFixed;
    [SerializeField] protected int face;
    [SerializeField] protected int count;

    public int index_;
    public string nomenclature_;
    public DiceRarity rarity_;
    public string description_;

    [SerializeField] protected int[] numbers_ = new int[6];
    [SerializeField] protected Sprite[] sprites_ = new Sprite[6];
    [SerializeField] protected int reroll_;

    [SerializeField] bool canFix = false;
    [SerializeField] protected bool canTrigger = false;

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
        face = 0;
        count = 0;

        canFix = false;
        canTrigger = false;

        CheckReroll();
    }

    public virtual void RollDice() {
        if (!isFixed) {
            face = Roll();
            GetComponent<SpriteRenderer>().sprite = sprites_[face];
            count++;
            canFix = true;
            CheckReroll();
        }
    }

    protected virtual int Roll() {
        Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
        return Random.Range(0, 6);
    }

    public void TriggerDice() {
        if (canTrigger) {           
            Trigger();
            canTrigger = false;
        }
    }

    protected virtual void Trigger() {
        // DO NOTHING HERE
    }

    void CheckReroll() {
        if (reroll_ < count) {
            FixDice();
            canFix = false;
        }
    }

    public void ToggleFixDice() {
        if (canFix) {
            if (isFixed) {
                UnfixDice();
            } else {
                FixDice();
            }
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

    public void ChangeNumbers(int[] newNumbers) {
        numbers_ = newNumbers;
    }

    public void IncreaseReroll() {
        reroll_++;
    }

    public virtual void GetDice(int set, int place) {
        // DO NOTHING HERE
    }

    public int GetNumber() {
        return numbers_[face];
    }
}
