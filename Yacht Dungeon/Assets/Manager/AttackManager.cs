using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {
    public static AttackManager Inst { get; private set; }

    public bool isAttacking = false;

    public GameObject meteor_; // enemy0_
    public GameObject enemy1_;
    public GameObject enemy2_;

    [SerializeField] int meteorHp;
    [SerializeField] int enemy1Hp;
    [SerializeField] int enemy2Hp;

    public GameObject SetDMG_;
    public GameObject DMGButton_;

    void Awake() {
        Inst = this;
    }

    private void Start() {
        for (int i = 1; i <= 3; i++) {
            isSetFired[i] = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (isAttacking) {

        }
    }

    public void Attack() {
        SetDMG_.transform.Translate(30, 0, 0);
        DMGButton_.transform.Translate(30, 0, 0);
        Camera.main.transform.position = new Vector2(30, 0);
        GetEnemyHp();
        isAttacking = true;
    }

    void GetEnemyHp() {
        int round = RoundManager.Inst.currentRound;
        meteorHp = EnemyManager.Inst.MeteorHp(round);
        enemy1Hp = EnemyManager.Inst.Enemy1Hp(round);
        enemy2Hp = EnemyManager.Inst.Enemy2Hp(round);
    }

    public void EndAttack() {
        SetDMG_.transform.Translate(-30, 0, 0);
        DMGButton_.transform.Translate(-30, 0, 0);
        isAttacking = false;
        // Call RoundManager or RewardManager
    }

    [SerializeField] int selectedSet;
    [SerializeField] int selectedDamage;
    [SerializeField] bool[] isSetFired = new bool[3];

    public void SelectSet(int set, int damage) {
        selectedSet = set;
        selectedDamage = damage;
    }

    public void FireSet(GameObject target) {
        if (isSetFired[selectedSet - 1]) { // Selected set is fired
            return;
        } else {
            if (!target.GetComponent<Entity>().IsAlive()) { // Target enemy is dead already
                return;
            } else {
                target.GetComponent<Entity>().Damaged(selectedDamage);
                isSetFired[selectedSet - 1] = true;
            }
        }
    }

    public void ResetDamage() {
        if (!isAttacking) {
            return;
        } else {
            meteor_.GetComponent<Entity>().ResetEntity();
            enemy1_.GetComponent<Entity>().ResetEntity();
            enemy2_.GetComponent<Entity>().ResetEntity();
            
            for (int i = 1; i <= 3; i++) {
                isSetFired[i] = false;
            }

            RoundManager.Inst.ChangeSetDamageBarSprite(-1);
        }
    }


}
