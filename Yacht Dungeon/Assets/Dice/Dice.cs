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

    [SerializeField] protected Sprite smallSprite_;
    [SerializeField] protected Sprite darkSprite_;

    [SerializeField] GameObject rerollDot_;

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

        MakeRerollDot();
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

    void MakeRerollDot() {
        switch (reroll_) {
            case 0:
                break;
            case 1:
                Vector2 pos1 = new Vector2(-0.03f, -1.05f);
                Instantiate(rerollDot_, pos1, Quaternion.identity, gameObject.transform).name = "Dot1";
                break;
            case 2:
                Vector2 pos2 = new Vector2(-0.09f, -1.05f);
                Instantiate(rerollDot_, pos2, Quaternion.identity, gameObject.transform).name = "Dot1";
                Vector2 pos3 = new Vector2(0.09f, -1.05f);
                Instantiate(rerollDot_, pos3, Quaternion.identity, gameObject.transform).name = "Dot2";
                break;
            case 3:
                Vector2 pos4 = new Vector2(-0.09f, -1.05f);
                Instantiate(rerollDot_, pos4, Quaternion.identity, gameObject.transform).name = "Dot1";
                Vector2 pos5 = new Vector2(-0.09f, -1.05f);
                Instantiate(rerollDot_, pos5, Quaternion.identity, gameObject.transform).name = "Dot2";
                Vector2 pos6 = new Vector2(-0.09f, -1.05f);
                Instantiate(rerollDot_, pos6, Quaternion.identity, gameObject.transform).name = "Dot3";
                break;
            default:
                Debug.Log("Error");
                break;
        }
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

    public GameObject diceKeep_;
    GameObject diceKeep;

    void FixDice() {
        isFixed = true;
        diceKeep = Instantiate(diceKeep_, transform);
    }

    void UnfixDice() {
        isFixed = false;
        Destroy(diceKeep);
    }

    public void ChangeNumbers(int[] newNumbers, Sprite[] newSprites) {
        numbers_ = newNumbers;
        sprites_ = newSprites;
    }

    public void IncreaseReroll() {
        reroll_++;
    }

    public virtual void GetDice(int set, int place) {
        // DO NOTHING HERE
    }

    public int GetReroll() {
        return reroll_ - count + 1;
    }

    public int GetNumber() {
        return numbers_[face];
    }

    public void ChangeSprite(bool changeToLarge) {
        if (changeToLarge) {
            GetComponent<SpriteRenderer>().sprite = sprites_[face];
        } else {
            GetComponent<SpriteRenderer>().sprite = smallSprite_;
        }
    }

    public void UpdateReroll() {
        int reroll = GetReroll();

    }
}
