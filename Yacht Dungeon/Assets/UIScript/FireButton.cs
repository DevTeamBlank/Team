using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour {

    [SerializeField] Sprite buttonSprite_;
    [SerializeField] Sprite pushedSprite_;
    public void ChangeSprite(bool isPushed) {
        GetComponent<SpriteRenderer>().sprite = isPushed ? pushedSprite_ : buttonSprite_;
    }

}
