using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRS {

    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public PRS (Vector3 v0, Quaternion q, Vector3 v1) {
        position = v0;
        rotation = q;
        scale = v1;
    }

    public PRS (Transform t) {
        position = t.position;
        rotation = t.rotation;
        scale = t.localScale;
    }

    public void Apply(Transform t) {
        t.position = position;
        t.rotation = rotation;
        t.localScale = scale;
    }
}
