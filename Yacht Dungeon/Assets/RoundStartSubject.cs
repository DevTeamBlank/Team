using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartSubject : Subject {
    public void CallArtifact() {
        foreach (Observer o in observers) {
            o.CallArtifact();
        }
    }
}
