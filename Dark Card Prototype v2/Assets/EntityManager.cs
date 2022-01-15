using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

    List<GameObject> entites;

    public static EntityManager Inst { get; private set; }

    void Awake() {
        Inst = this;
        entites = new List<GameObject>();
    }


    public void GiveDamage(GameObject target) {

    }
}
