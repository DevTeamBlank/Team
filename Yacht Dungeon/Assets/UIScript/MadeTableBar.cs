using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadeTableBar : MonoBehaviour {

    public MadeTable.Made made;
    [SerializeField] Sprite barSprite_;
    [SerializeField] Sprite onMouseSprite_;
    [SerializeField] Sprite usedSprite_;

    public bool canSelect = true;

    RaycastHit2D hit;
    GameObject go;

    void Update() {
        OnMouse();
    }

    [SerializeField] bool onMouse = false;

    void OnMouse() {
        if (!canSelect) return;

        hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);
        if (hit) {
            go = hit.transform.gameObject;
            if (go == this) {
                if (!onMouse) {
                    onMouse = true;
                    ChangeSprite(Sprites.onMouse);
                }
                
            }
        }
        if (onMouse) {
            onMouse = false;
            ChangeSprite(Sprites.normal);
        }
    }

    public void Click() {
        if (!canSelect) return;

        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == this) {
                    // MadeTable
                    MadeTable.Inst.SelectMade(made);
                }
            } else {
                Debug.Log(hit);
            }
        }
    }

    public void BanMade() {
        canSelect = false;
        ChangeSprite(Sprites.used);
    }

    public void ResetMade() {
        canSelect = true;
        ChangeSprite(Sprites.normal);
    }

    enum Sprites {
        normal,
        onMouse,
        used
    }

    void ChangeSprite(Sprites spr) {
        switch (spr) {
            case Sprites.normal:
                GetComponent<SpriteRenderer>().sprite = barSprite_;
                break;
            case Sprites.onMouse:
                GetComponent<SpriteRenderer>().sprite = onMouseSprite_;
                break;
            case Sprites.used:
                GetComponent<SpriteRenderer>().sprite = usedSprite_;
                break;
        }
    }
}
