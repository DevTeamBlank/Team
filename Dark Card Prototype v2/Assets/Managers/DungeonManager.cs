using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DungeonManager : MonoBehaviour { // DungeonManager´Â ÇÑ Scene¿¡¼­ ½Ì±ÛÅæ.
    public static DungeonManager Inst { get; private set; }

    public GameObject[] levelManagers;

    [SerializeField] int currentLevel = 0;

    [SerializeField] string nextScene;

    void Awake() {
        Inst = this;
    }

    void Start() {
        DungeonSetting(0);
    }

    void DungeonSetting(int level) {
        currentLevel = level;
        for (int i = 0; i < levelManagers.Length; i++) {
            levelManagers[i].SetActive(false);
        }
        levelManagers[level].SetActive(true);
        levelManagers[level].GetComponent<LevelManager>().Setting();
        float z = Camera.main.transform.position.z;
        Vector2 pos = levelManagers[level].transform.position;
        Camera.main.transform.position = new Vector3(pos.x, pos.y, z);
    }

    void NextLevel() {
        switch (currentLevel) {
            case 0:
                DungeonSetting(1);
                break;
            case 1:
                DungeonSetting(2);
                break;
            case 2:
                DungeonCleared();
                break;
        }
    }

    public void LevelCleared() {
        NextLevel();
    }

    public void DungeonCleared() {
        SceneManager.LoadScene(nextScene);
    }

}
