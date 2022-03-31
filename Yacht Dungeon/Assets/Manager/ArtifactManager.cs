using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour {

    public static ArtifactManager Inst { get; private set; }

    [SerializeField] int artifact;
    [SerializeField] List<GameObject> artifacts = new List<GameObject>(15);

    public GameObject[] artifactDB_ = new GameObject[30]; // DataBase

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        artifact = 0;
        MakeList();
    }

    public void Load(Save save) {
        artifact = save.artifact;
        MakeList();
    }

    void MakeList() {
        int seed = GameManager.Seed;
        bool[] bools = new bool[artifactDB_.Length];
        for (int i = 0; i < 15; i++) {
            int random;
            do {
                Random.InitState(seed + 23);
                random = Random.Range(0, artifactDB_.Length);
            } while (!bools[random]);
            bools[random] = true;
            artifacts.Add(artifactDB_[random]);
        }
    }

    public void TakeArtifact() {
        artifacts[artifact].GetComponent<Artifact>().Enable();
        artifact++;
    }

}
