using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour {

    private Vector3 startPosition;
    private float startZ; // == maxZ

    public float maxScope;
    private float maxZ;
    private float minZ;

    public float cameraMoveSpeed;
    public bool canMove;

    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
        startZ = startPosition.z;

        maxZ = startZ;
        minZ = maxScope * maxZ;

        canMove = true;
    }

    float mouseWheel;
    float nextZ;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    float nextX;
    float nextY;

    // Update is called once per frame
    void Update() {
        if (canMove) {
            if (Input.GetKey(KeyCode.Space)) { // Space to reset setting
                transform.position = startPosition;
            }

            mouseWheel = Input.mouseScrollDelta.y; // Wheel to adjust scope
            nextZ = transform.position.z + mouseWheel;
            if (minZ <= nextZ && nextZ <= maxZ) {
                transform.Translate(new Vector3(0, 0, mouseWheel));
            }

            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) { // Horizontal Moves
                nextX = transform.position.x - cameraMoveSpeed;
                if (minX <= nextX && nextX <= maxX) {
                    transform.Translate(new Vector3(-cameraMoveSpeed, 0, 0));
                }
            } else if (!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) {
                nextX = transform.position.x + cameraMoveSpeed;
                if (minX <= nextX && nextX <= maxX) {
                    transform.Translate(new Vector3(cameraMoveSpeed, 0, 0));
                }
            }

            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) { // Vertical Moves
                nextY = transform.position.y + cameraMoveSpeed;
                if (minY <= nextY && nextY <= maxY) {
                    transform.Translate(new Vector3(0, cameraMoveSpeed, 0));
                }
            } else if (!Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) {
                nextY = transform.position.y - cameraMoveSpeed;
                if (minY <= nextY && nextY <= maxY) {
                    transform.Translate(new Vector3(0, -cameraMoveSpeed, 0));
                }
            }
        }
    }
}
