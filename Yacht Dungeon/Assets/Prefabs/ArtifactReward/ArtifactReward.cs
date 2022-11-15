using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactReward : MonoBehaviour {

    [SerializeField] int index_;
    [SerializeField] Sprite description_;

    bool isChosen = false;
    RaycastHit2D hit;

    private void Update() {

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

        if (hit.collider != null && hit.collider.gameObject == gameObject) {
            ArtifactRewardManager.Inst.ChangeDescription(description_);
        }

        if (Input.GetMouseButtonDown(0)) {
            if (hit.collider != null && hit.collider.gameObject == gameObject) {
                isChosen = true;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            if (hit.collider != null && hit.collider.gameObject == gameObject && isChosen) {
                isChosen = false;
                ArtifactManager.Inst.TakeArtifact(index_);
                ArtifactRewardManager.Inst.ChoseReward();
            }
        }
    }

}
