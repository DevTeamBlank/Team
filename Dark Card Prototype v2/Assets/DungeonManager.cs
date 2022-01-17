using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {
    public static DungeonManager Inst { get; private set; }

    public GameObject[] levelManagers;
    public bool[] levelCleared;

    [SerializeField] int currentLevel;

    void Awake() {
        Inst = this;
    }

    public void GoNextLevel(int nextLevel) { // Button
        levelManagers[currentLevel].SetActive(false);
        levelManagers[nextLevel].SetActive(true);
        currentLevel = nextLevel;
        levelManagers[currentLevel].GetComponent<LevelManager>().Setting();
        CardManager.Inst.Setting();
    }
}
