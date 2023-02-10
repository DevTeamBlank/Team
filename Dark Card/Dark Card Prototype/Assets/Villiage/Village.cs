using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void Upgrade() {

    }

    void Heal() {
        GameObject health = GameObject.Find("Health");
        health.GetComponent<Health>().MaxHeal();
    }

    void Craft() {
        
    }
}
