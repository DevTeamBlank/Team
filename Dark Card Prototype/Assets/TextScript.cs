using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {

    public bool isVisible;

    public string attachedTo;
    private GameObject _gameObject;

    // Start is called before the first frame update
    void Start() {
        _gameObject = GameObject.Find("attachedTo");
    }

    // Update is called once per frame
    void Update() {
        if (isVisible) {
            // TODO
        } else {
            // TODO
        }
    }
}
