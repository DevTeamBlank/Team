using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public int ID;
    public string nomenclature;

    public Rarity rarity;
    public int energy;

    public enum Rarity {
        starter,
        common,
        uncommon,
        rare
    }

    public AttackType attackType;

    public enum AttackType {
        nan,
        target,
        random,
        all
    }

    public virtual void Play() { }

    public void Order() {
        // TODO
    }

}
