using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice10 : Dice {

    protected override void Trigger() {
        face = 5 - face;
        GetComponent<SpriteRenderer>().sprite = sprites_[face];
    }

}
