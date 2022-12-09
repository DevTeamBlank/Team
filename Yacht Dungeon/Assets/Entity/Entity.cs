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

    [SerializeField] GameObject hpT_;

    void Start() {
        onAnimation = false;
        time = 0f;
        count = 0;

        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    protected void HPUpdate() {
        hpT_.name = "HP: " + hp.ToString();
        TextManager.Inst.ChangeText(hp, hpT_, TextManager.TextMode.Default);
    }


    public void Damaged(int damage) {
        if (hp <= damage) {
            hp = 0;
            HPUpdate();
            Destroy();
        } else {
            hp -= damage;
            HPUpdate();
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
        HPUpdate();
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
