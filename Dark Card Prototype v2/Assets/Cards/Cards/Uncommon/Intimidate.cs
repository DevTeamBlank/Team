using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intimidate : Card {

    [SerializeField] int weakness;

    protected override void PlayCard() {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ApplyWeakness(weakness, attackType);
    }
}
