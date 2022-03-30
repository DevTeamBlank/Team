using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour {
    
    public static int offset;

    [SerializeField] int artifact_;
    [SerializeField] List<GameObject> artifacts_ = new List<GameObject>(15);

    public GameObject[] artifactDB = new GameObject[30]; // DataBase

    public void StartGame() {
        artifact_ = 0;
        MakeList();
    }

    public void Load(Save save) {
        artifact_ = save.artifact;
        MakeList();
    }

    void MakeList() {
        int seed = GameManager.Seed;
        bool[] bools = new bool[artifactDB.Length];
        for (int i = 0; i < 15; i++) {
            int random;
            do {
                Random.InitState(seed + offset);
                random = Random.Range(0, artifactDB.Length);
            } while (!bools[random]);
            bools[random] = true;
            artifacts_.Add(artifactDB[random]);
        }
    }

    public void TakeArtifact() {
        artifact_++;

    }


}
