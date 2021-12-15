using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour {

    private Vector3 startPosition;
    private float startZ; // == maxZ

    public float maxScope;
    private float maxZ;
    private float minZ;

    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
        startZ = startPosition.z;

        maxZ = startZ;
        minZ = maxScope * maxZ;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            transform.position = startPosition;
        } else if (Input.GetMouseButton(1)) {

        }

        float mouseWheel = Input.mouseScrollDelta.y;
        float nextZ = transform.position.z + mouseWheel;
        if (minZ <= nextZ && nextZ <= maxZ) {
            transform.Translate(new Vector3(0, 0, mouseWheel));
        }

    }
}
