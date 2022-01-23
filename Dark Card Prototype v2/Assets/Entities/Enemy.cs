using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    public int EnemyID;

    public int patterns;
    [SerializeField] Sprite[] intents;
    [SerializeField] int currPattern;

    public override void BattleStart() {
        DecidePattern();
    }

    public void TurnStart() {
        Patterns(currPattern);
        DecidePattern();
    }

    public virtual void Patterns(int index) { }

    void DecidePattern() {
        currPattern = Random.Range(0, patterns);
        transform.Find("Intent").GetComponent<SpriteRenderer>().sprite = intents[currPattern];
    }
    protected override void Dead() {
        GetComponentInParent<LevelManager>().EnemyDead(index);
    }
}
