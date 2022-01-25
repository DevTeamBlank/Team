using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    [Header("These are about intents & patterns.")]
    public int patterns;
    [SerializeField] protected Sprite[] intents;
    [SerializeField] protected int currPattern;

    public override void BattleStart() {
        DecidePattern();
    }

    public virtual void TurnStart() {
        Patterns(currPattern);       
    }

    public virtual void Patterns(int index) { }

    protected void DecidePattern() {
        currPattern = Random.Range(0, patterns);
        transform.Find("Intent").GetComponent<SpriteRenderer>().sprite = intents[currPattern];
    }

    public virtual void TurnEnd() {
        DecidePattern();
    }

    protected override void Dead() {
        GetComponentInParent<LevelManager>().EnemyDead(index);
    }
}
