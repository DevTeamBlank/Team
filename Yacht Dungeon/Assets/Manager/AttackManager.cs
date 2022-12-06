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
    public GameObject[] SetDMGs_ = new GameObject[3];
    public GameObject DMGButton_;

    void Awake() {
        Inst = this;
    }

    public void Attack() {
        SetDMG_.transform.Translate(30, 0, 0);
        DMGButton_.transform.Translate(30, 0, 0);
        Camera.main.transform.position = new Vector3(30, 0, -10);
        SetEnemyHp();
        isAttacking = true;

        selectedSet = 1;
        RoundManager.Inst.ChangeSetDamageBarSprite(1);
        selectedDamage = SetDMGs_[0].GetComponent<SetDamageBar>().currentDamage;
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

        Camera.main.transform.position = new Vector3(60, 0, -10);
        RoundManager.Inst.RoundEnd(!meteor_.GetComponent<Meteor>().IsAlive());
    }

    [SerializeField] int selectedSet = 1;
    [SerializeField] int selectedDamage;

    public void SelectEntity(bool meteor, int index = 0) {
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

    public void FireSet(GameObject target) {
        if (!target.GetComponent<Entity>().IsAlive()) { // Target enemy is dead already
            return;
        } else {
            target.GetComponent<Entity>().Damaged(selectedDamage);
            NextSet();
        }
    }

    void NextSet() {
        if (selectedSet == 3) {
            selectedSet = 1;
            EndAttack();
        }
        selectedSet++;
        RoundManager.Inst.ChangeSetDamageBarSprite(selectedSet);
        selectedDamage = SetDMGs_[selectedSet - 1].GetComponent<SetDamageBar>().currentDamage;
    }

    public void ResetDamage() {
        if (!isAttacking) {
            return;
        } else {
            meteor_.GetComponent<Entity>().ResetEntity();
            enemy1_.GetComponent<Entity>().ResetEntity();
            enemy2_.GetComponent<Entity>().ResetEntity();

            selectedSet = 1;
            RoundManager.Inst.ChangeSetDamageBarSprite(1);
            selectedDamage = SetDMGs_[0].GetComponent<SetDamageBar>().currentDamage;
        }
    }


}
