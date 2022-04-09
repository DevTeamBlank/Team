using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {

    [HideInInspector] public int bonus = 0;
    Artifact artifact;

    public Observer(Artifact a, int b = 0) {
        artifact = a;
        bonus = b;
        
    }

    public void AddSubject(Subject s) {
        s.AddObserver(this);
    }

    public void OnNotify(int[] num) {
        bonus = artifact.CalculateBonus(num);
    }

    public int Bonus() {        
        return bonus;
    }

}
