using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disarm : Card {

    [SerializeField] int lostStrength;

    protected override void PlayCard() {
        int gainStrength = lostStrength * -1;
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GainStrength(gainStrength, attackType);
    }
}
