using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : Card {

    [SerializeField] int weakness;
    [SerializeField] int vulnerable;

    protected override void PlayCard() {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ApplyWeakness(weakness, attackType);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ApplyVulnerable(vulnerable, attackType);
    }
}
