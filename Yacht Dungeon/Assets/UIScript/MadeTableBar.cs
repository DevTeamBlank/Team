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
    GameObject target;

    void Update() {
        OnMouse();
        Click();
    }

    [SerializeField] bool onMouse = false;

    void OnMouse() {
        if (!canSelect) return;

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);
        if (hit.collider != null) {
            target = hit.collider.gameObject;
            if (target == gameObject) {
                if (!onMouse) {
                    onMouse = true;
                    ChangeSprite(Sprites.onMouse);
                }                
            } else {
                onMouse = false;
                ChangeSprite(Sprites.normal);
            }
        } else {
            onMouse = false;
            ChangeSprite(Sprites.normal);
        }
    }

    public void Click() {
        if (!canSelect) return;

        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.transform.gameObject;
                if (target == gameObject) {
                    MadeTable.Inst.SelectMade(made);
                    MadeTable.Inst.UpdateMadeTable();
                }
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
