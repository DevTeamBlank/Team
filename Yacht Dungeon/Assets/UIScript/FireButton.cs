using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour {

    public static FireButton Inst { get; private set; }

    [SerializeField] Sprite buttonSprite_;
    [SerializeField] Sprite pushedSprite_;
    public void ChangeSprite(bool isPushed) {
        GetComponent<SpriteRenderer>().sprite = isPushed ? pushedSprite_ : buttonSprite_;
    }

    public void FireDamage() {
        // TODO
    }
}
