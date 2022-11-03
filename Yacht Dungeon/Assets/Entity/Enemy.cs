using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    public Sprite[] sprites_ = new Sprite[6];

    void Update() {
        if (onAnimation) {
            time += Time.deltaTime;
            if (animationDelay_ <= time) {
                if (count < sprites_.Length - 1) {
                    time = 0;
                    count++;
                    GetComponent<SpriteRenderer>().sprite = sprites_[count];
                } else {
                    onAnimation = false;
                    time = 0;
                    count = 0;
                    // TODO
                    // RoundManager »£√‚
                    Destroy(gameObject);
                }                
            }
        }    
    }

}
