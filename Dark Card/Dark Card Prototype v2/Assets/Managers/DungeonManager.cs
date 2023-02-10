using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
        Player.Inst.MaxHeal();
    }

    static int dungeon = 0;

    void DungeonSetting(int level) {
        GameObject.Find("LevelUI").GetComponent<TextMeshPro>().text = (dungeon + 1) + " - " + (level + 1);

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

    public void NextLevel() {
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
        levelManagers[currentLevel].GetComponent<LevelManager>().LevelCleared();
    }

    public void DungeonCleared() {
        Player.Inst.MaxHeal();
        dungeon++;
        SceneManager.LoadScene(nextScene);       
    }

}
