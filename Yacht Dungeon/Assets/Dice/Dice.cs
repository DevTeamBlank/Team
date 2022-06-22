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
    [SerializeField] protected Sprite[] smallSprite_ = new Sprite[6];
    [SerializeField] protected int reroll_;

    [SerializeField] bool canFix = false;
    [SerializeField] protected bool canTrigger = false;

    [SerializeField] GameObject[] rerollDots;
    GameObject diceKeep;

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
            if (0 < count) UpdateDot();
            count++;
            canFix = true;
            CheckReroll();
            
        }
    }

    public void UpdateDot() {
        rerollDots[count - 1].GetComponent<RerollDot>().ChangeSprite(false);
    }

    protected virtual int Roll() {
        // Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
        int random = Random.Range(0, 6);
        return random;
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
                rerollDots = new GameObject[1];
                Vector2 pos1 = (Vector2)transform.position + new Vector2(-0.03f, -1.05f);
                rerollDots[0] = Instantiate(DiceManager.Inst.rerollDot_, pos1, Quaternion.identity, gameObject.transform);
                rerollDots[0].name = "Dot1";
                break;
            case 2:
                rerollDots = new GameObject[2];
                Vector2 pos2 = (Vector2)transform.position + new Vector2(-0.09f, -1.05f);
                rerollDots[0] = Instantiate(DiceManager.Inst.rerollDot_, pos2, Quaternion.identity, gameObject.transform);
                rerollDots[0].name = "Dot1";
                Vector2 pos3 = (Vector2)transform.position + new Vector2(0.09f, -1.05f);
                rerollDots[1] = Instantiate(DiceManager.Inst.rerollDot_, pos3, Quaternion.identity, gameObject.transform);
                rerollDots[1].name = "Dot2";
                break;
            case 3:
                rerollDots = new GameObject[3];
                Vector2 pos4 = (Vector2)transform.position + new Vector2(-0.21f, -1.05f);
                rerollDots[0] = Instantiate(DiceManager.Inst.rerollDot_, pos4, Quaternion.identity, gameObject.transform);
                rerollDots[0].name = "Dot1";
                Vector2 pos5 = (Vector2)transform.position + new Vector2(-0.03f, -1.05f);
                rerollDots[1] = Instantiate(DiceManager.Inst.rerollDot_, pos5, Quaternion.identity, gameObject.transform);
                rerollDots[1].name = "Dot2";
                Vector2 pos6 = (Vector2)transform.position + new Vector2(0.15f, -1.05f);
                rerollDots[2] = Instantiate(DiceManager.Inst.rerollDot_, pos6, Quaternion.identity, gameObject.transform);
                rerollDots[2].name = "Dot3";
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

    void FixDice() {
        isFixed = true;
        diceKeep = Instantiate(DiceManager.Inst.diceKeep_, transform);
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
            for (int i = 0; i < rerollDots.Length; i++) {
                rerollDots[i].GetComponent<SpriteRenderer>().enabled = true;
            }
            GetComponent<BoxCollider2D>().size = new Vector2(1.62f, 1.62f);
        } else {
            GetComponent<SpriteRenderer>().sprite = smallSprite_[face];
            for (int i = 0; i < rerollDots.Length; i++) {
                rerollDots[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            GetComponent<BoxCollider2D>().size = new Vector2(1.08f, 1.08f);
        }
    }

    public void UpdateReroll() {
        int reroll = GetReroll();
    }

    float time = 0f;
    RaycastHit2D hit;

    void Update() {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

        if (hit.collider != null && hit.collider.gameObject == gameObject) {
            time += Time.deltaTime;
            if (1 < time && !hasPopUp) MakePopUp();
        } else {
            time = 0;
            if (hasPopUp) DestroyPopUp();
        }
        
    }

    bool hasPopUp;
    GameObject dicePopUp;

    void MakePopUp() {
        hasPopUp = true;
        Vector2 pos = transform.position;
        float x = pos.x;
        float y = pos.y;
        float offset = DiceManager.Inst.popUpOffset_;
        if (0 < x && 0 < y) {
            pos += new Vector2(-1 * offset, -1 * offset);
        } else if (0 < x && y <= 0) {
            pos += new Vector2(-1 * offset, offset);
        } else if (x <= 0 && 0 < y) {
            pos += new Vector2(offset, -1 * offset);
        } else {
            pos += new Vector2(offset, offset);
        }
        dicePopUp = Instantiate(DiceManager.Inst.dicePopUp_, pos, Quaternion.identity, gameObject.transform);
    }

    void DestroyPopUp() {
        hasPopUp = false;
        Destroy(dicePopUp);
    }
}
