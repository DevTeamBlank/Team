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

    public void NextSet() {
        int set = RoundManager.Inst.currentSet;
        ChangeSetSprite(set);
        ChangeDiceRollPosition(set);
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
            set1[i].transform.position = dice8SetPosition_;
            set2[i].transform.position = dice8SetPosition_;
            set3[i].transform.position = dice8SetPosition_;
            float offsetX = (i - 2) * setPositionOffsetX_;
            set1[i].transform.Translate(new Vector2(offsetX, -setPositionOffsetY_));
            set2[i].transform.Translate(new Vector2(offsetX, 0));
            set3[i].transform.Translate(new Vector2(offsetX, setPositionOffsetY_));
            ChangeDiceSprite(set1[i], false);
            ChangeDiceSprite(set2[i], false);
            ChangeDiceSprite(set3[i], false);
        }
    }

    void ChangeDiceSprite(GameObject dice, bool changeToLarge) {
        dice.GetComponent<Dice>().ChangeSprite(changeToLarge);
    }

}


