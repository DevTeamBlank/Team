using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public string nomenclature_;
    public int hp_;
    [SerializeField] protected float animationDelay_;
    protected bool onAnimation;
    protected float time;
    protected int count;

    void Start() {
        onAnimation = false;
        time = 0f;
        count = 0;
    }

    public void Damaged(int damage) {
        if (hp_ <= damage) {
            Destroy();
        }
    }

    public void Destroy() {
        onAnimation = true;
    }
}
