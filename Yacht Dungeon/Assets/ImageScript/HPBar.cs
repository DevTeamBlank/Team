using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

    [SerializeField] Sprite fullSprite;
    [SerializeField] Sprite emptySprite;

    GameObject[] hpBars;
    GameObject hpBar2;
    GameObject hpBar3;
    GameObject hpBar4;
    GameObject hpBar5;

    public void Start() {
        hpBars = new GameObject[5];
        for (int i = 0; i < 5; i++) {
            hpBars[i] = transform.Find("HPBarEmpty" + (i+1).ToString()).gameObject;
        }
    }

    public void UpdateHP(int hp) {
        for (int i = 0; i < hp; i++) {
            hpBars[i].GetComponent<SpriteRenderer>().sprite = fullSprite;
        }
        for (int i = hp; i < 5; i++) {
            hpBars[i].GetComponent<SpriteRenderer>().sprite = emptySprite;
        }
    }
}
