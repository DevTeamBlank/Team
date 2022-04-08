using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour {

    public static ArtifactManager Inst { get; private set; }

    [SerializeField] List<int> artifactIndex = new List<int>(15);
    [SerializeField] List<GameObject> artifacts = new List<GameObject>(15);

    public GameObject[] artifactDB_ = new GameObject[40]; // DataBase

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        artifactIndex = new List<int>();
        MakeList();
    }

    public void Load(Save save) {
        artifactIndex = save.artifact;
        MakeList();
    }

    void MakeList() {
        for (int i = 0; i < artifactIndex.Count; i++) {
            TakeArtifact(artifactIndex[i]);
        }
    }

    public void TakeArtifact(int index) {
        GameObject go = artifactDB_[index];
        artifacts.Add(go);
        go.GetComponent<Artifact>().Enable();
    }

}
