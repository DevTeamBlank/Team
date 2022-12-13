using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {

    int bonus = 0;
    GameObject artifact;

    /*
    public Observer(Artifact a) {
        artifact = a;   
    }
    */

    public void SetArtifact(GameObject go) {
        artifact = go;
    }

    public void AddSubject(Subject s) {
        s.AddObserver(this);
    }

    public void OnNotify(int[] num) {
        bonus = artifact.GetComponent<Artifact>().CalculateBonus(num);
    }

    public int Bonus() {        
        return bonus;
    }

    public void CallArtifact() {
        artifact.GetComponent<Artifact>().Notify();
    }

}
