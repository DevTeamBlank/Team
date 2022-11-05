using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour {

    [SerializeField] bool isEnabled = false;

    public int index_;
    public string nomenclature_;
    public ArtifactType type_;
    public ArtifactRarity rarity_;
    public string description_;

    [SerializeField] Sprite smallSprite_;
    [SerializeField] Sprite largeSprite_;

    public enum ArtifactRarity {
        Basic,
        Common,
        Uncommon,
        Rare
    }

    public enum ArtifactType {
        Made,
        Set,
        Update
    }

    public void Enable() {
        isEnabled = true;
        switch (type_) {
            case ArtifactType.Made:
                EnableMade();
                break;
            case ArtifactType.Set:
                EnableSet();
                break;
            case ArtifactType.Update:
                EnableUpdate();
                break;
        }
    }

    public virtual void EnableMade() {
        // DO NOTHING HERE
        // Implemented by derived classes
    }

    public virtual void EnableSet() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.setS);
    }

    public virtual void EnableUpdate() {
        // DO NOTHING HERE
        // Implemented by derived classes
    }

    public virtual void Notify() {
        // DO NOTHING HERE
        // Implemented by derived classes
    }

    public void ChangeSprite(bool changeToLarge) {
        if (changeToLarge) {
            GetComponent<SpriteRenderer>().sprite = largeSprite_;
            GetComponent<BoxCollider2D>().size = new Vector2(1.62f, 1.62f);
        } else {
            GetComponent<SpriteRenderer>().sprite = smallSprite_;
            GetComponent<BoxCollider2D>().size = new Vector2(1.08f, 1.08f);
        }
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
    GameObject artifactPopUp;

    void MakePopUp() {
        hasPopUp = true;
        Vector2 pos = transform.position;
        float x = pos.x;
        float y = pos.y;
        float offset = 1;
        if (0 < x && 0 < y) {
            pos += new Vector2(-1 * offset, -1 * offset);
        } else if (0 < x && y <= 0) {
            pos += new Vector2(-1 * offset, offset);
        } else if (x <= 0 && 0 < y) {
            pos += new Vector2(offset, -1 * offset);
        } else {
            pos += new Vector2(offset, offset);
        }
        artifactPopUp = Instantiate(ArtifactManager.Inst.artifactPopUp_, pos, Quaternion.identity, gameObject.transform);
    }

    void DestroyPopUp() {
        hasPopUp = false;
        Destroy(artifactPopUp);
    }

    // Below protected methods are used in derived classes' override methods

    protected bool Contain(int[] num, int n) {
        for (int i = 0; i < num.Length; i++) {
            if (num[i] == n) return true;
        }
        return false;
    }


    protected int[] GetIndex() {
        int set = RoundManager.Inst.currentSet;
        int[] dices = new int[5];
        for (int i = 0; i < 5; i++) {
            dices[i] = DiceManager.Inst.diceIndex[set, i];
            }
            return dices;
    }

    protected GameObject[] GetDice() {
        switch (RoundManager.Inst.currentSet) {
            case 1:
                return DiceManager.Inst.set1;
            case 2:
                return DiceManager.Inst.set2;
            case 3:
                return DiceManager.Inst.set3;
            default:
                return null;
        }
    }

    protected int Kinds(int[] nums) {
        int ret = 1;
        for (int i = 1; i < nums.Length; i++) {
            bool flag = true;
            for (int j = 0; j < i; j++) {
                if (nums[i] == nums[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                ret++;
            }
        }
        return ret;
    }

    protected int[] Sort(int[] num) {
        int[] c = new int[num.Length];
        for(int i = 0; i< num.Length; i++) {
            c[i] = num[i];
        }
        Array.Sort(c);
        return c;
    }

    // break //

    public virtual int CalculateBonus(int[] num) {
        // DO NOTHING HERE other than return 0;
        return 0;
    }

}
