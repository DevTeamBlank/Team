using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour {

    public static ArtifactManager Inst { get; private set; }

    [SerializeField] List<GameObject> artifacts = new List<GameObject>(15);
    [SerializeField] List<int> artifactIndex = new List<int>(15);

    public GameObject[] artifactDB_ = new GameObject[40]; // DataBase
    public GameObject artifactPopUp_;
    public float popUpOffset_ = 1f;
    bool[] artifactGet = new bool[40];

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        artifactIndex = new List<int>(15);
        MakeList();
    }

    public void Load(Save save) {
        artifactIndex = save.artifact;
        MakeList();
    }

    void MakeList() {
        artifacts = new List<GameObject>(15);
        for (int i = 0; i < artifactGet.Length; i++) {
            artifactGet[i] = false;
        }
        for (int i = 0; i < artifactIndex.Count; i++) {
            TakeArtifact(artifactIndex[i]);
        }
    }

    public void TakeArtifact(int index) {
        GameObject go = artifactDB_[index];
        artifacts.Add(go);
        artifactGet[index] = true;
        go.GetComponent<Artifact>().Enable();
    }

}
