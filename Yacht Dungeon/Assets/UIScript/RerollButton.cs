using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollButton : MonoBehaviour {

    public static RerollButton Inst { get; private set; }

    [SerializeField] Sprite buttonSprite_;
    [SerializeField] Sprite pushedSprite_;

    RerollDot dot1;
    RerollDot dot2;
    RerollDot dot3;

    void Start() {
        dot1 = transform.Find("Dot1").GetComponent<RerollDot>();
        dot2 = transform.Find("Dot2").GetComponent<RerollDot>();
        dot3 = transform.Find("Dot3").GetComponent<RerollDot>();
    }

    public void ChangeSprite(bool isPushed) {
        GetComponent<SpriteRenderer>().sprite = isPushed ? pushedSprite_ : buttonSprite_;
    }

    public void ResetReroll() {
        dot1.ChangeSprite();
        dot2.ChangeSprite();
        dot3.ChangeSprite();
    }

    public void UpdateDot() {
        ResetReroll();
        int reroll = RoundManager.Inst.currentRoll;
        switch (reroll) {
            case 0:
                dot1.ChangeSprite(false);
                dot2.ChangeSprite(false);
                dot3.ChangeSprite(false);
                break;
            case 1:
                dot2.ChangeSprite(false);
                dot3.ChangeSprite(false);
                break;
            case 2:
                dot3.ChangeSprite(false);
                break;
        }
    }

    public void RerollSet() {
        RoundManager.Inst.RollSet();
    }
}
