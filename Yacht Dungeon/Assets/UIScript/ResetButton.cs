using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {
    public static ResetButton Inst { get; private set; }

    [SerializeField] Sprite buttonSprite_;
    [SerializeField] Sprite pushedSprite_;
    public void ChangeSprite(bool isPushed) {
        GetComponent<SpriteRenderer>().sprite = isPushed ? pushedSprite_ : buttonSprite_;
    }

    public void ResetDamage() {
        // TODO
    }
}
