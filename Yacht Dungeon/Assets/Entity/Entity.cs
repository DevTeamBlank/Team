using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public string nomenclature_;
    [SerializeField] protected int maxHp;
    [SerializeField] protected int hp;
    [SerializeField] protected float animationDelay_;
    protected bool onAnimation;
    protected float time;
    protected int count;

    void Start() {
        onAnimation = false;
        time = 0f;
        count = 0;

        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    

    public void Damaged(int damage) {
        if (hp <= damage) {
            hp = 0;
            Destroy();
        }
    }

    public void Destroy() {
        onAnimation = true;
    }

    public bool IsAlive() {
        return 0 < hp;
    }

    Sprite sprite;

    public void ResetEntity() {
        hp = maxHp;
        onAnimation = false;
        time = 0f;
        count = 0;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public virtual void SetMaxHp() {
        // DO NOTHING HERE
        // Implemented by derived classes (Enemy.cs and Meteor.cs)
    }

    protected virtual void SelectEntity() {
        // DO NOTHING HERE
        // Implemented by derived classes (Enemy.cs and Meteor.cs)
    }
}
