using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardDatabase : MonoBehaviour {

    public static CardDatabase Inst { get; private set; }

    [SerializeField] List<GameObject> cardDatabase;
    List<GameObject> commonCards = new List<GameObject>();
    List<GameObject> uncommonCards = new List<GameObject>();
    List<GameObject> rareCards = new List<GameObject>();

    public GameObject GetCard(int ID) {
        if (ID < 0 || cardDatabase.Count <= ID) {
            Debug.Log("Unvalid ID.");
            return null;
        }
        return cardDatabase[ID];
    }

    void Awake() {
        Inst = this;
    }

    void Start() {
        CardDBSetting();
    }

    void CardDBSetting() {
        isRewarding = false;
        levelCleared = false;

        for (int i = 0; i < cardDatabase.Count; i++) {
            GameObject card = cardDatabase[i];
            Card.Rarity rarity = card.GetComponent<Card>().GetRarity();

            switch (rarity) {
                case Card.Rarity.common:
                    commonCards.Add(card);
                    break;
                case Card.Rarity.uncommon:
                    uncommonCards.Add(card);
                    break;
                case Card.Rarity.rare:
                    rareCards.Add(card);
                    break;
                default:
                    break;
            }
        }
    }

    float x0, x1, x2;
    float y;

    Vector2[] positions;

    void GetXYPosition() {
        Vector2 center = Camera.main.transform.position;

        x1 = center.x;
        x0 = x1 - rewardIntervalX;
        x2 = x1 + rewardIntervalX;

        y = center.y + rewardOffsetY;

        positions = new Vector2[3];
        positions[0] = new Vector2(x0, y);
        positions[1] = new Vector2(x1, y);
        positions[2] = new Vector2(x2, y);
    }

    [SerializeField] float rewardIntervalX;
    [SerializeField] float rewardOffsetY;

    [SerializeField] GameObject[] rewards;
    [SerializeField] int[] rewardIDs;

    [SerializeField] bool isRewarding;

    public void Reward(bool rare = false) {
        GetXYPosition();
        if (rare) {
            rewardIDs = GetRareRewardIDs();
        } else {
            rewardIDs = GetRewardIDs();
        }
        Sprite[] sprites = new Sprite[3];
        rewards = new GameObject[3];
        for (int i = 0; i < 3; i++) {
            sprites[i] = GetCard(rewardIDs[i]).GetComponent<SpriteRenderer>().sprite;
            rewards[i] = new GameObject("Reward " + i);
            rewards[i].AddComponent<SpriteRenderer>();
            rewards[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
            rewards[i].GetComponent<SpriteRenderer>().sortingLayerName = "Card";
            rewards[i].transform.position = positions[i];
        }
        isRewarding = true;
    }

    void Update() {
        if (isRewarding) {
            if (Input.GetKeyDown(KeyCode.Keypad1)) {
                AddCard(true, rewardIDs[0]);
            } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
                AddCard(true, rewardIDs[1]);
            } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
                AddCard(true, rewardIDs[2]);
            } else if (Input.GetKeyDown(KeyCode.Keypad0)) {
                AddCard(false);
            } else if (Input.GetKeyDown(KeyCode.KeypadPeriod)) {
                AddCard(false);
            }
        } else {
            if (Input.GetKeyDown(KeyCode.KeypadPeriod)) {
                Reward();
            }
        }
    }

    public void LevelCleared() {
        Debug.Log("WhoFuckcalled");
        levelCleared = true;
    }

    [SerializeField] bool levelCleared;

    void AddCard(bool add, int ID = 0) {
        if (add) {
            Deck.Inst.AddCard(ID);
        }
        for (int i = 0; i < 3; i++) {
            GameObject.Destroy(rewards[i]);
        }
        isRewarding = false;
        if (levelCleared) {
            levelCleared = false;
            StartCoroutine(Wait(2f));
            DungeonManager.Inst.NextLevel();            
        }
    }

    public int[] GetRareRewardIDs() {
        int[] rewardIDs = RandomPickID(rareCards, 3);
        return rewardIDs;
    }

    public int[] GetRewardIDs() {
        int random = Random.Range(0, 4);
        int[] rewardIDs = new int[3];

        switch (random) {
            case 0:
                rewardIDs = RandomPickID(commonCards, 3);
                break;
            case 1:
                rewardIDs = RandomPickID(uncommonCards, 1).Concat(RandomPickID(commonCards, 2)).ToArray();
                break;
            case 2:
                rewardIDs = RandomPickID(uncommonCards, 2).Concat(RandomPickID(commonCards, 1)).ToArray();
                break;
            case 3:
                rewardIDs = RandomPickID(uncommonCards, 3);
                break;
        }

        return rewardIDs;
    }

    public int[] RandomPickID(List<GameObject> list, int number) {

        for (int i = list.Count - 1; i > 0; i--) {
            int random = Random.Range(0, i); ;
            GameObject temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }

        int[] ret = new int[number];
        for (int i = 0; i < number; i++) {
            ret[i] = list[i].GetComponent<Card>().GetCardID();
        }

        return ret;
    }

    IEnumerator Wait (float second) {
        yield return new WaitForSeconds(second);
    }

}
