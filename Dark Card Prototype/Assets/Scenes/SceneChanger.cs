using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    private int gold;
    private GameObject deck;
    private GameObject player;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadCredit() {
        SceneManager.LoadScene("Credit");

    }

    public void GetGold(int gold) {
        this.gold = gold;
    }

    public void GetDeck(GameObject deck) {
        this.deck = deck;
    }

    public void GetPlayer(GameObject player) {
        this.player = player;
    }

    public int SetGold() {
        return gold;
    }
}
