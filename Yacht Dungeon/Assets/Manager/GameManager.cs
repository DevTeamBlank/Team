using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int Seed { get; private set; }

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void StartGame() {
        
    }

    void CreateSeed() {
        Seed = (int) (Time.time * 100f);
        Random.InitState(Seed);
    }

    void LoadSeed(Save save) {
        Random.InitState(save.seed);
    }

    void SaveGame() {
        // Save save = new Save(
    }

    void LoadGame(Save save) {
        LoadSeed(save);
        Player.Inst.Load(save);
    }
}
