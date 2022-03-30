using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour {

    [SerializeField] bool isEnabled_;

    public int ID;
    public string nomenclature;
    public string description;

    public virtual void Enable() {
        
    }

}
