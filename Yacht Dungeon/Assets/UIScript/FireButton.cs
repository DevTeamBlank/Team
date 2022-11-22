using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireButton : MonoBehaviour {

    [SerializeField] Sprite buttonSprite_;
    [SerializeField] Sprite pushedSprite_;

    void ChangeSprite(bool isPushed) {
        GetComponent<SpriteRenderer>().sprite = isPushed ? pushedSprite_ : buttonSprite_;
    }

    RaycastHit2D hit;
    GameObject target;

    private void Update() {
        FireDamage();
    }

    void FireDamage() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == gameObject) {
                    ChangeSprite(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == gameObject) {
                    ChangeSprite(false);
                    // TODO
                }
            }
        }
    }

}
