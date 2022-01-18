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
        Reward(); // Temporary Card
    }

    void CardDBSetting() {
        isRewarding = false;


        for (int i = 0; i < cardDatabase.Count; i++) {
            GameObject card = cardDatabase[i];
            Card.Rarity rarity = card.GetComponent<Card>().GetRarity();

            switch (rarity) {
                case Card.Rarity.starter:
                    break;
                case Card.Rarity.common:
                    commonCards.Add(card);
                    break;
                case Card.Rarity.uncommon:
                    uncommonCards.Add(card);
                    break;
                case Card.Rarity.rare:
                    rareCards.Add(card);
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

    public void Reward() {
        GetXYPosition();
        rewardIDs = GetRewardIDs();
        Sprite[] sprites = new Sprite[3];
        rewards = new GameObject[3];
        for (int i = 0; i < 3; i++) {
            sprites[i] = GetCard(rewardIDs[i]).GetComponent<SpriteRenderer>().sprite;
            rewards[i] = new GameObject("Reward " + i);
            rewards[i].AddComponent<SpriteRenderer>();
            rewards[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
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
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Keypad0)) {
                Reward();
            }
        }        
    }

    void AddCard(bool add, int ID = 0) {
        if (add) {
            Deck.Inst.AddCard(ID);
            Debug.Log("Card ID " + ID + " added in the deck.");
        }
        for (int i = 0; i < 3; i++) {
            GameObject.Destroy(rewards[i]);
        }
        isRewarding = false;
    }


    public int[] GetRewardIDs() {
        int[] ret = { 1, 2, 3 }; // Temporary Code
        return ret;

        int random = Random.Range(0, 4);
        int[] rewardIDs;

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
            default:
                Debug.Log("Unvalid random value.");
                rewardIDs = new int[3];
                break;
        }

        return rewardIDs;
    }

    public int[] RandomPickID(List<GameObject> list, int number) {
        int[] ret = new int[number];

        for (int i = 0; i < number; i++) {
            bool duplicated = true;
            int cardID = -1;

            while (duplicated) {
                int random = Random.Range(0, list.Count);
                cardID = list[random].GetComponent<Card>().GetCardID();

                for (int j = 0; j < i; j++) {
                    if (cardID == ret[j]) {
                        duplicated = true;
                        break;
                    }
                    duplicated = false;
                }

            }

            ret[i] = cardID;
        }

        return ret;
    }

    public void RareReward() {
        for (int i = 0; i < rareCards.Count; i++) {

        }
    }

}
