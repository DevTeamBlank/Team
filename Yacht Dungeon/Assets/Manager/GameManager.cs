using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] public static int Seed { get; private set; }
    public static GameManager Inst { get; private set ;}

    void Awake() {
        Inst = this;
    }

    void Start() {
        StartGame();
    }

    void Update() {

    }
   

    void CreateSeed() {
        Seed = Random.Range(0, 100);
        Debug.Log("Seed: " + Seed);
    }

    void LoadSeed(Save save) {
        Seed = save.seed;
    }

    public void SaveGame() {
        // Save save = new Save(
    }

    void StartGame() {
        CreateSeed();
        Player.Inst.StartGame();
        ArtifactManager.Inst.StartGame();
        DiceManager.Inst.StartGame();
        RoundManager.Inst.StartGame();
    }

    void LoadGame(Save save) {
        LoadSeed(save);
        Player.Inst.Load(save);
        RoundManager.Inst.Load(save);
        ArtifactManager.Inst.Load(save);
        DiceManager.Inst.Load(save);
    }

    public void GameOver() {
        Debug.Log("Game Over");
        // TODO
    }
}
