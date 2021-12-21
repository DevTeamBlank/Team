using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {
   
    private Sprite sprite;
    private GameObject display;
    private GameObject displayOnly;

    void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;

        // temp
        displayScale = 2;
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
}
