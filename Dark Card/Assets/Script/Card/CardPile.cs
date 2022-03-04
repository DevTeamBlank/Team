using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour {

    [SerializeField] protected List<GameObject> list_;

    public void Add(GameObject g) {
        list_.Add(g);
    }

    public bool isEmpty() {
        return list_.Count == 0;
    }

    public GameObject Pop() {
        if (isEmpty()) return null;
        GameObject g = list_[0];
        list_.Remove(g);
        return g;
    }

    public void Shuffle() {
        for (int i = list_.Count - 1; i > 0; i--) {
            int rnd = Random.Range(0, i); ;
            GameObject g = list_[i];
            list_[i] = list_[rnd];
            list_[rnd] = g;
        }
    }

    [SerializeField] bool isShowing_;

    public void Show() {
        if (isShowing_) return;
        // TODO
        isShowing_ = true;
    }

    public void Hide() {
        if (isShowing_) return;
        // TODO
        isShowing_ = false;
    }

}
