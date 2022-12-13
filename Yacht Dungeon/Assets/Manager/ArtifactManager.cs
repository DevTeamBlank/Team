using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour {

    public static ArtifactManager Inst { get; private set; }

    int count = 0;
    [SerializeField] List<GameObject> artifacts = new List<GameObject>(15);
    [SerializeField] List<int> artifactIndex = new List<int>(15);

    public GameObject[] artifactDB_ = new GameObject[40]; // DataBase
    bool[] artifactGet = new bool[40];

    public GameObject artifactObserver_;
    [SerializeField] GameObject[] artifactPositions = new GameObject[15];

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        MakeList();
    }

    void MakeList() {
        artifacts = new List<GameObject>(15);
        for (int i = 0; i < artifactGet.Length; i++) {
            artifactGet[i] = false;
        }
    }

    public void TakeArtifact(int index) {
        Debug.Log("Taking this artifact");
        GameObject go = Instantiate(artifactDB_[index]);
        artifacts.Add(go);
        artifactIndex.Add(index);
        artifactGet[index] = true;
        go.transform.position = artifactPositions[count].transform.position;
        count++;
        go.GetComponent<Artifact>().Enable();
    }

    public List<int> RemainingIndexes() {
        List<int> list = new List<int>();
        for (int i = 0; i < artifactGet.Length; i++) {
            if (!artifactGet[i]) list.Add(i);
        }
        return list;
    }

    [SerializeField] GameObject[] rewardArtifacts_ = new GameObject[40]; // This is different from Database, please put prefabs here.

    public GameObject RewardArtifact(int index) {
        return Instantiate(rewardArtifacts_[index]);
    }

    public void DiceRewardToArtifactReward() {
        for (int i = 0; i < artifacts.Count; i++) {
            artifacts[i].transform.Translate(new Vector2(0, -15));
        }
    }

    public void ArtifactRewardToMain() {
        for (int i = 0; i < artifacts.Count; i++) {
            artifacts[i].transform.Translate(new Vector2(-60, 15));
        }
    }

    public void MainToDiceReward() {
        for (int i = 0; i < artifacts.Count; i++) {
            artifacts[i].transform.Translate(new Vector2(60, 0));
        }
    }

    public void DiceRewardToMain() {
        for (int i = 0; i < artifacts.Count; i++) {
            artifacts[i].transform.Translate(new Vector2(-60, 0));
        }
    }
}
