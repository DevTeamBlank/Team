using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff00 : MonoBehaviour {
    private GameObject _gameObject;

    public int value;

    // Start is called before the first frame update
    void Start() {
        _gameObject = transform.GetComponentInParent<GameObject>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Act() {
        // TODO
    }
}
