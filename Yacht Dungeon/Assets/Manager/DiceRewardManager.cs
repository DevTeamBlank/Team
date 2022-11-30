using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRewardManager : MonoBehaviour {

    public static DiceRewardManager Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    [SerializeField] int rewardNumber = 2;
    [SerializeField] GameObject[] positions_ = new GameObject[5];
    [SerializeField] GameObject description_;

    void Start() {

    }

    [SerializeField] int[] indexes = new int[3];

    public void StartDiceReward() {
        SetIndexes();
        MakeRewards();
    }


    void SetIndexes() {
        List<int> list = DiceManager.Inst.RemainingIndexes();
        if (list.Count < rewardNumber) {
            Debug.Log("Error!");
            for(int i = 0; i < indexes.Length; i++) {
                indexes[i] = -1;
            }
            return;
        }

        indexes[0] = list[Random.Range(0, list.Count)];
        list.Remove(indexes[0]);
        indexes[1] = list[Random.Range(0, list.Count)];
        list.Remove(indexes[1]);
        if (rewardNumber == 2) {
            indexes[2] = -1;
        } else {
            indexes[2] = list[Random.Range(0, list.Count)];
        }
    }

    void MakeRewards() {
        if (rewardNumber == 2) {
            GameObject reward0 = DiceManager.Inst.RewardDice(indexes[0]);
            reward0.transform.parent = positions_[0].transform;
            reward0.transform.position = positions_[0].transform.position;
            reward0.name = "Reward0: Dice" + indexes[0].ToString();

            GameObject reward1 = DiceManager.Inst.RewardDice(indexes[1]);
            reward1.transform.parent = positions_[1].transform;
            reward1.transform.position = positions_[1].transform.position;
            reward1.name = "Reward1: Dice" + indexes[1].ToString();
        } else { // if (rewardNumber == 3)
            GameObject reward0 = DiceManager.Inst.RewardDice(indexes[0]);
            reward0.transform.parent = positions_[3].transform;
            reward0.transform.position = positions_[3].transform.position;
            reward0.name = "Reward0: Dice" + indexes[0].ToString();

            GameObject reward1 = DiceManager.Inst.RewardDice(indexes[1]);
            reward1.transform.parent = positions_[4].transform;
            reward1.transform.position = positions_[4].transform.position;
            reward1.name = "Reward1: Dice" + indexes[1].ToString();

            GameObject reward2 = DiceManager.Inst.RewardDice(indexes[2]);
            reward1.transform.parent = positions_[5].transform;
            reward1.transform.position = positions_[5].transform.position;
            reward1.name = "Reward2: Dice" + indexes[2].ToString();
        }
    }

    public void ChangeDescription(Sprite sprite) {
        description_.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void ChoseReward() {
        if (RoundManager.Inst.gettingArtifact) {
            Camera.main.transform.position = new Vector3(60, -15, -10);
            ArtifactRewardManager.Inst.StartArtifactReward();
        } else {
            Camera.main.transform.position = new Vector3(0, 0, -10);
            RoundManager.Inst.NextRound();
        }
    }
}
