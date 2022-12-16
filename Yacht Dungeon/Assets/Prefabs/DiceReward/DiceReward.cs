using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceReward : MonoBehaviour {

    [SerializeField] int index_;
    [SerializeField] Sprite smallSprite_;
    [SerializeField] Sprite description_;

    RaycastHit2D hit;
    bool isChosen = false;

    Vector2 originalPosition;
    Sprite originalSprite;

    private void Start() {
        originalPosition = gameObject.transform.position;
        originalSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void Update() {
        if (isChosen) {
            gameObject.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

        if (hit.collider != null && hit.collider.gameObject == gameObject) {
            DiceRewardManager.Inst.ChangeDescription(description_);
        }

        if (Input.GetMouseButtonDown(0)) {
            if (hit.collider != null && hit.collider.gameObject == gameObject) {
                GetComponent<SpriteRenderer>().sprite = smallSprite_;
                isChosen = true;
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            if (isChosen) {
                isChosen = false;
                int set10place = DiceManager.Inst.DiceSetPlace(new Vector2(60, 0)); // DiceReward Screen's position is 60, 0, 0
                if (set10place == -1) { // The mouse position is invalid or have another special dice already
                    gameObject.transform.position = originalPosition;
                    GetComponent<SpriteRenderer>().sprite = originalSprite;
                } else {
                    DiceManager.Inst.ChangeDice(set10place / 10, set10place % 10, index_);
                    // Destroy(gameObject);
                    DiceRewardManager.Inst.ChoseReward();
                }
            }
        }
    }

}
