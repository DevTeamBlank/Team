using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    void Start() {
        
    }

    private void Update() {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }    
}
