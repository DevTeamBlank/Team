using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour {

    public static Set Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    [SerializeField] Sprite set1Sprite_;
    [SerializeField] Sprite set2Sprite_;
    [SerializeField] Sprite set3Sprite_;

    [SerializeField] Vector3 dice3RollPosition_;
    [SerializeField] float rollPositionOffset_;

    [SerializeField] Vector3 dice8SetPosition_;
    [SerializeField] float setPositionOffsetX_;
    [SerializeField] float setPositionOffsetY_;

    [SerializeField] GameObject nameTagSet_;

    public void StartSet() {
        int set = RoundManager.Inst.currentSet;
        ChangeSetSprite(set);
        ChangeDiceRollPosition(set);
        MadeTable.Inst.StartSet();
    }

    void ChangeSetSprite(int set) {
        switch (set) {
            case 0:
                nameTagSet_.GetComponent<SpriteRenderer>().sprite = null;
                break;
            case 1:
                nameTagSet_.GetComponent<SpriteRenderer>().sprite = set1Sprite_;
                break;
            case 2:
                nameTagSet_.GetComponent<SpriteRenderer>().sprite = set2Sprite_;
                break;
            case 3:
                nameTagSet_.GetComponent<SpriteRenderer>().sprite = set3Sprite_;
                break;
        }
    }

    public void ChangeDiceRollPosition(int set) {
        ChangeDiceSetPosition();
        if (set == 1) {
            ChangeDiceRollPositionSet(DiceManager.Inst.set1);
        } else if (set == 2) {
            ChangeDiceRollPositionSet(DiceManager.Inst.set2);
        } else if (set == 3) {
            ChangeDiceRollPositionSet(DiceManager.Inst.set3);
        }
    }

    void ChangeDiceRollPositionSet(GameObject[] set) {
        for (int i = 0; i < 5; i++) {
            set[i].transform.position = dice3RollPosition_;
            float offsetX = (i - 2) * rollPositionOffset_;
            set[i].transform.Translate(new Vector2(offsetX, 0));
            ChangeDiceSprite(set[i], true);
        }
    }

    void ChangeDiceSetPosition() {
        GameObject[] set1 = DiceManager.Inst.set1;
        GameObject[] set2 = DiceManager.Inst.set2;
        GameObject[] set3 = DiceManager.Inst.set3;
        for (int i = 0; i < 5; i++) {
            set1[i].transform.position = DicePositionInSet(1, i + 1);
            set2[i].transform.position = DicePositionInSet(2, i + 1);
            set3[i].transform.position = DicePositionInSet(3, i + 1);
            /*
            set1[i].transform.position = dice8SetPosition_;
            set2[i].transform.position = dice8SetPosition_;
            set3[i].transform.position = dice8SetPosition_;
            float offsetX = (i - 2) * setPositionOffsetX_;
            set1[i].transform.Translate(new Vector2(offsetX, -setPositionOffsetY_));
            set2[i].transform.Translate(new Vector2(offsetX, 0));
            set3[i].transform.Translate(new Vector2(offsetX, setPositionOffsetY_));
            */
            ChangeDiceSprite(set1[i], false);
            ChangeDiceSprite(set2[i], false);
            ChangeDiceSprite(set3[i], false);
        }
    }

    void ChangeDiceSprite(GameObject dice, bool changeToLarge) {
        dice.GetComponent<Dice>().ChangeSprite(changeToLarge);
    }

    public Vector2 DicePositionInSet(int set, int place) {
        Vector2 vec = dice8SetPosition_;
        switch (set) {
            case 1:
                vec += new Vector2(0, -setPositionOffsetY_);
                break;
            case 2:
                break;
            case 3:
                vec += new Vector2(0, setPositionOffsetY_);
                break;
            default:
                Debug.Log("Error");
                break;
        }
        float offsetX = (place - 3) * setPositionOffsetX_;
        vec += new Vector2(offsetX, 0);

        return vec;
    }

    public void DiceRewardToArtifactReward() {
        GameObject[] set1 = DiceManager.Inst.set1;
        GameObject[] set2 = DiceManager.Inst.set2;
        GameObject[] set3 = DiceManager.Inst.set3;
        for (int i = 0; i < 5; i++) {
            set1[i].transform.Translate(new Vector2(0, -15));
            set2[i].transform.Translate(new Vector2(0, -15));
            set3[i].transform.Translate(new Vector2(0, -15));
        }
    }
}


