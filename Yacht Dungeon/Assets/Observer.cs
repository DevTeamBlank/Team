using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {

    int bonus = 0;
    Artifact artifact;

    public Observer(Artifact a) {
        artifact = a;   
    }

    public Observer() { }

    public void AddSubject(Subject s) {
        s.AddObserver(this);
    }

    public void OnNotify(int[] num) {
        bonus = artifact.CalculateBonus(num);
    }

    public int Bonus() {        
        return bonus;
    }

    public void CallArtifact() {
        artifact.Notify();
    }

}
