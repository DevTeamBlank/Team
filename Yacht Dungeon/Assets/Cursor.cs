using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    void Start() {
        
    }

    RaycastHit2D hit;
    GameObject go;

    void Update() {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)){
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go.tag == "Dice") {
                    go.GetComponent<Dice>().ToggleFixDice();
                }
            } else {
                Debug.Log(hit);
            }
        }        
    }
}
