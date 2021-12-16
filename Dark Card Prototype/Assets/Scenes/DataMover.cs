using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataMover : MonoBehaviour {

    public bool isSceneChanged;

    // Start is called before the first frame update
    void Start() {
        isSceneChanged = false;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
        if (isSceneChanged) {
            SaveData();
            LoadData();
            isSceneChanged = false;
        }
    }

    private int gold;
    private GameObject player;
    private GameObject deck;

    void SaveData() {
        gold = GameObject.Find("Gold").GetComponent<Gold>().GetGold();
        player = GameObject.FindGameObjectWithTag("Player");
        deck = GameObject.Find("Deck");
    }

    void LoadData() {
        GameObject.Find("Gold").GetComponent<Gold>().SetGold(gold);
    }
}
