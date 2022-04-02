using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject {

    List<Observer> observers;

    public Subject() {
        ResetList();
    }

    public void AddObserver(Observer o) {
        observers.Add(o);
    }

    public void ResetList() {
        observers = new List<Observer>();
    }

    public void Notify() {
        foreach (Observer o in observers) {
            o.OnNotify();
        }
    }
}

