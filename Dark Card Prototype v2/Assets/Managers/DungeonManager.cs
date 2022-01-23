using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour { // DungeonManager´Â ÇÑ Scene¿¡¼­ ½Ì±ÛÅæ.
    public static DungeonManager Inst { get; private set; }

    public GameObject[] levelManagers;
    [SerializeField] bool[] levelCleared;

    [SerializeField] int currentLevel = 0;

    void Awake() {
        Inst = this;
    }

    void Start() {
        DungeonSetting();
    }

    void DungeonSetting() {
        levelCleared = new bool[levelManagers.Length];
        for (int i = 0; i < levelManagers.Length; i++) {
            levelManagers[i].SetActive(false);
            levelCleared[i] = false;
        }
        levelManagers[currentLevel].SetActive(true);
        levelManagers[currentLevel].GetComponent<LevelManager>().Setting();
    }

    void NextLevel() {
        // TODO
        // Button activate
        // GoNextLevel(1);
    }

    public void GoNextLevel(int nextLevel) { // Interact with buttons
        levelManagers[currentLevel].SetActive(false);
        levelManagers[nextLevel].SetActive(true);
        currentLevel = nextLevel;
        levelManagers[currentLevel].GetComponent<LevelManager>().Setting();
    }

    public void LevelCleared() {
        levelCleared[currentLevel] = true;
        CheckDungeonClear();
        NextLevel();
    }

    public void CheckDungeonClear() {
        for (int i = 0; i < levelCleared.Length; i++) {
            if (!levelCleared[i]) return;
        }
        // TODO
        // Reward
        // Scene Change
    }
}
