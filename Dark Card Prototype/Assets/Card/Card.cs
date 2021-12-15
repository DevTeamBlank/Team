using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public int ID;
    public string nomenclature;

    public int cost; // -1: Unusable
    public int cardType; // 0: Attack, 1: Skill, 2: Power, 3: Disturb

    public bool hasTarget;
    public int validTargetType;
    /* 0: NaN, 1: Player, 2: Enemy, 4: Object
     * Most of cards are 0, 1, 6 */

    protected virtual void Played(GameObject target) {
        // GameObject battleManager = GameObject.FindGameObjectWithTag("BattleManager");
    }

    private Sprite sprite;
    private GameObject display;
    private GameObject displayOnly;

    void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
    }
    
    public void Display(Vector2 position) {
        display = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
        displayOnly.AddComponent<SpriteRenderer>();
        displayOnly.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public void HideDisplay() {
        Destroy(display);
    }

    public float displayScale;

    public void DisplayOnly() {
        displayOnly = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
        displayOnly.transform.localScale = new Vector2(displayScale, displayScale);
        displayOnly.AddComponent<SpriteRenderer>();
        displayOnly.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void HideDisplayOnly() {
        Destroy(displayOnly);
    }

    // Implement in inherited class
    public virtual void Played() {

    }
}
