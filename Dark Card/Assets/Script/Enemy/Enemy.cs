using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Entity : MonoBehaviour { // Enemies, Objects

    public readonly string nomenclature;

    public readonly int hp;
    public readonly int hpOffset;
    [SerializeField] int health_;

    [SerializeField] int block_;
    [SerializeField] bool isAlive = true;

    public void Setting() {
        health_ = hp;

    }

    public virtual void BattleStart() { }

    public virtual void TurnStart() { }

    public virtual void TurnEnd() { }

    protected virtual void Dead() {
        isAlive = false;
    }
}
