using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour {

    [SerializeField] bool isEnabled;

    public int ID_;
    public string nomenclature_;
    public string description_;

    public virtual void Enable() {
        
    }

}
