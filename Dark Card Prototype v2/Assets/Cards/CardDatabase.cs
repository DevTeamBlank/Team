using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {

    public static CardDatabase Inst { get; private set; }

    [SerializeField] List<GameObject> cardDatabase;
    List<GameObject> commonCards;
    List<GameObject> uncommonCards;
    List<GameObject> rareCards;

    void Awake() {
        Inst = this;
    }

    void Start() {
        CardDBSetting();
    }

    void CardDBSetting() {
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

    public void Reward() {

    }

    public GameObject[] GetRewardArray() {
        int uncommons = Random.Range(0, 4);
        GameObject[] rewards = new GameObject[3];

        if (uncommons == 0) {
            rewards = RandomPick(commonCards, 3 - uncommons);
        } else if (uncommons == 3) {
            rewards = RandomPick(commonCards, 3 - uncommons);
        } else {
            GameObject[] uncommonRewards = RandomPick(uncommonCards, uncommons);
            GameObject[] commonRewards = RandomPick(commonCards, 3 - uncommons);
            for (int i = 0; i < uncommons; i++) {
                rewards[i] = uncommonRewards[i];
            }
            for (int i = uncommons; i < 3; i++) {
                rewards[i] = commonRewards[i - uncommons];
            }
        }

        return rewards;
    }

    public GameObject[] RandomPick(List<GameObject> list, int number) {
        GameObject[] ret = new GameObject[number];
        // TODO
        // Randomly pick number times
        return ret;
    }

    public void RareReward() {
        for (int i = 0; i < rareCards.Count; i++) {

        }
    }

}
