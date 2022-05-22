using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollButton : MonoBehaviour {

    public static RerollButton Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    [SerializeField] Sprite buttonSprite_;
    [SerializeField] Sprite pushedSprite_;

    [SerializeField] GameObject[] dots = new GameObject[3];

    public void ChangeSprite(bool isPushed) {
        GetComponent<SpriteRenderer>().sprite = isPushed ? pushedSprite_ : buttonSprite_;
    }

    void ResetReroll() {
        for (int i = 0; i<3; i++) {
            dots[i].GetComponent<RerollDot>().ChangeSprite();
        }
    }

    public void UpdateDot() {
        ResetReroll();
        int reroll = RoundManager.Inst.currentRoll;
        switch (reroll) {
            case 0:
                dots[0].GetComponent<RerollDot>().ChangeSprite(false);
                dots[1].GetComponent<RerollDot>().ChangeSprite(false);
                dots[2].GetComponent<RerollDot>().ChangeSprite(false);
                break;
            case 1:
                dots[1].GetComponent<RerollDot>().ChangeSprite(false);
                dots[2].GetComponent<RerollDot>().ChangeSprite(false);
                break;
            case 2:
                dots[2].GetComponent<RerollDot>().ChangeSprite(false);
                break;
        }
    }
}
