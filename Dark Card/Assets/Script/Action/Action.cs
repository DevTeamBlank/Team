using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {

    public enum Type {
        Damage,
        Draw
    }

    public Type type;
    public GameObject target;
    public Object obj;    

    Action(Type t, GameObject g, Object o) {
        type = t;
        target = g;
        obj = o;
    }

}
