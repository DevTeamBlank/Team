using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Sprite[] sprites_ = new Sprite[8];
    [SerializeField] float animationDelay_;
    bool onAnimation;
    float time;
    int count;

    private void Start() {
        onAnimation = true;
        time = 0;
        count = 0;
    }

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
                    Destroy(gameObject);
                }
            }
        }
    }

}
