using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollDot : MonoBehaviour {

    [SerializeField] Sprite brightSprite_;
    [SerializeField] Sprite darkSprite_;

    public void ChangeSprite(bool isBright = true) {
        GetComponent<SpriteRenderer>().sprite = isBright ? brightSprite_ : darkSprite_;
    }
}
