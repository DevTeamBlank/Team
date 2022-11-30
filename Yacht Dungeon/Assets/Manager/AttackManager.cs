using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {
    public static AttackManager Inst { get; private set; }

    public bool isAttacking = false;

    public GameObject meteor_; // enemy0_
    public GameObject enemy1_;
    public GameObject enemy2_;

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

    public void Attack() {
        SetDMG_.transform.Translate(30, 0, 0);
        DMGButton_.transform.Translate(30, 0, 0);
        Camera.main.transform.position = new Vector2(30, 0);
        SetEnemyHp();
        isAttacking = true;
    }

    void SetEnemyHp() {
        meteor_.GetComponent<Entity>().SetMaxHp();
        enemy1_.GetComponent<Entity>().SetMaxHp();
        enemy2_.GetComponent<Entity>().SetMaxHp();
    }

    public void EndAttack() {
        if (enemy1_.GetComponent<Enemy>().IsAlive()) {
            Player.Inst.Damaged();
        }
        if (enemy2_.GetComponent<Enemy>().IsAlive()) {
            Player.Inst.Damaged();
        }

        SetDMG_.transform.Translate(-30, 0, 0);
        DMGButton_.transform.Translate(-30, 0, 0);
        isAttacking = false;

        RoundManager.Inst.RoundEnd(!meteor_.GetComponent<Meteor>().IsAlive());
    }

    [SerializeField] bool isSelecting = false;
    [SerializeField] int selectedSet;
    [SerializeField] int selectedDamage;
    [SerializeField] bool[] isSetFired = new bool[3];

    public void SelectSet(int set, int damage) {
        isSelecting = true;
        selectedSet = set;
        selectedDamage = damage;
    }

    public void SelectEntity(bool meteor, int index = 0) {
        if (!isSelecting) {
            Debug.Log("Please select a Set first");
        } else {
            if (meteor || index == 0) {
                FireSet(meteor_);
            } else { // if the target entity is an enemy
                if (index == 1) {
                    FireSet(enemy1_);
                } else { // if (index == 2)
                    FireSet(enemy2_);
                }
            }
        }
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
                isSelecting = false;
                if (CheckAllFired()) { // Fired all sets
                    EndAttack();
                }
            }
        }
    }

    bool CheckAllFired() {
        return isSetFired[0] && isSetFired[1] && isSetFired[2];
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
