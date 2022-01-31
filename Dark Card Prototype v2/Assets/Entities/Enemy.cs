using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : Entity {

    [Header("These are about intents & patterns.")]
    public int patterns;
    [SerializeField] protected Sprite[] intents;
    [SerializeField] protected int[] damages;
    [SerializeField] protected int currPattern;

    public override void BattleStart() {
        DecidePattern();
    }

    public override void TurnStart() {
        base.TurnStart();
        Patterns(currPattern);       
    }
    public override void TurnEnd() {
        base.TurnEnd();
        DecidePattern();
    }

    public virtual void Patterns(int index) { }

    protected void DecidePattern() {
        currPattern = Random.Range(0, patterns);
        UpdateIntent(intents[currPattern]);
        UpdateDamage(damages[currPattern]);
    }

    protected void UpdateIntent(Sprite sprite) {
        transform.Find("Intent").GetComponent<SpriteRenderer>().sprite = sprite;
    }
    protected void UpdateIntent() {
        transform.Find("Intent").GetComponent<SpriteRenderer>().sprite = intents[currPattern];
    }

    protected void UpdateDamage(int damage) {
        if (damage == -1) {
            transform.Find("Damage").GetComponent<TextMeshPro>().text = "";
        } else {
            transform.Find("Damage").GetComponent<TextMeshPro>().text = damage.ToString();
        }
    }
    protected void UpdateDamage() {
        if (damages[currPattern] == -1) {
            transform.Find("Damage").GetComponent<TextMeshPro>().text = "";
        } else {
            transform.Find("Damage").GetComponent<TextMeshPro>().text = damages[currPattern].ToString();
        }
    }


    protected override void Dead() {
        GetComponentInParent<LevelManager>().EnemyDead(index);
    }
}
