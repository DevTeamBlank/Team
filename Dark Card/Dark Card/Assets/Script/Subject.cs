using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject {

    List<Observer> observers;

    public Subject() {
        observers = new List<Observer>();
    }

    public void AddObserver(Observer o) {
        observers.Add(o);
    }

    public void RemoveObserver(Observer o) {
        observers.Remove(o);
    }

    public void Notify() {
        foreach (Observer o in observers) {
            o.OnNotify();
        }
    }
}
