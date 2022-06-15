using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public static RoundManager Inst { get; private set; }

    public int currentRound;
    public int currentSet;
    public int currentRoll;
    public int[] currentNumbers = new int[5];

    [SerializeField] GameObject[] setDamageBar_ = new GameObject[3];

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        currentRound = 0;
        currentSet = 1;
        currentRoll = 0;
        RoundStart();
    }

    [SerializeField] int chest; // enemy0
    [SerializeField] int enemy1;
    [SerializeField] int enemy2;

    public int set1Damage;
    public int set2Damage;
    public int set3Damage;

    public void Load(Save save) {
        currentRound = save.clearedRound;
        currentSet = 1;
        currentRoll = 0;
    }

    RaycastHit2D hit;
    GameObject target;

    void Update() {
        RollDice();
        ToggleDice();
        TriggerDice();
        if (choseDamage) {
            FireDamage();
            ResetDamage();
        }
    }

    [SerializeField] GameObject rerollButton_;

    void RollDice() {
        if (currentRoll >= 3) return;

        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == rerollButton_) {
                    RerollButton.Inst.ChangeSprite(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == rerollButton_) {
                    RerollButton.Inst.ChangeSprite(false);
                    RollSet();
                    MadeTable.Inst.UpdateMadeTable();
                }
            }
        }
    }

    void ToggleDice() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target.tag == "Dice") {
                    target.GetComponent<Dice>().ToggleFixDice();
                }
            }
        }
    }

    void TriggerDice() {
        if (Input.GetMouseButtonDown(1)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target.tag == "Dice") {
                    target.GetComponent<Dice>().TriggerDice();
                }
            }
        }
    }

    [SerializeField] GameObject fireButton_;
    [SerializeField] GameObject resetButton_;

    void FireDamage() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == fireButton_) {
                    fireButton_.GetComponent<FireButton>().ChangeSprite(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == fireButton_) {
                    fireButton_.GetComponent<FireButton>().ChangeSprite(false);
                    // TODO
                }
            }
        }
    }

    void ResetDamage() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == resetButton_) {
                    ResetButton.Inst.ChangeSprite(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == resetButton_) {
                    ResetButton.Inst.ChangeSprite(false);
                    ResetButton.Inst.ResetDamage();
                }
            }
        }
    }

    public void RollSet() {
        DiceManager.Inst.RollSet();
        currentRoll++;
        RerollButton.Inst.UpdateDot();
        currentNumbers = DiceManager.Inst.GetNumbers();
        // MadeTable
    }

    [HideInInspector] public RoundStartSubject roundStartS;

    void RoundStart() {
        // roundStartS.CallArtifact();
        chest = EnemyManager.Inst.ChestHp(currentRound);
        enemy1 = EnemyManager.Inst.GetComponent<EnemyManager>().Enemy1Hp(currentRound);
        enemy2 = EnemyManager.Inst.GetComponent<EnemyManager>().Enemy2Hp(currentRound);
        ChangeSetDamageBarSprite(currentSet);
    }

    public void SetDamage(int damage) {
        switch (currentSet) {
            case 1:
                set1Damage = damage;
                setDamageBar_[0].GetComponent<SetDamageBar>().DamageUpdate(damage);
                break;
            case 2:
                set2Damage = damage;
                setDamageBar_[1].GetComponent<SetDamageBar>().DamageUpdate(damage);
                break;
            case 3:
                set3Damage = damage;
                setDamageBar_[2].GetComponent<SetDamageBar>().DamageUpdate(damage);
                break;
            default:
                Debug.Log("Error");
                break;
        }
        
        NextSet();
    }

    bool choseDamage = false;

    void NextSet() {
        if (currentSet == 1 || currentSet == 2) {
            currentSet++;
            ChangeSetDamageBarSprite(currentSet);
            Set.Inst.NextSet();
            DiceManager.Inst.RollSet();
        } else {
            choseDamage = true;
        }
    }

    void ChangeSetDamageBarSprite(int set) {
        switch (set) {
            case 1:
                setDamageBar_[0].GetComponent<SetDamageBar>().ChangeSprite(true);
                setDamageBar_[1].GetComponent<SetDamageBar>().ChangeSprite(false);
                setDamageBar_[2].GetComponent<SetDamageBar>().ChangeSprite(false);
                break;
            case 2:
                setDamageBar_[0].GetComponent<SetDamageBar>().ChangeSprite(false);
                setDamageBar_[1].GetComponent<SetDamageBar>().ChangeSprite(true);
                setDamageBar_[2].GetComponent<SetDamageBar>().ChangeSprite(false);
                break;
            case 3:
                setDamageBar_[0].GetComponent<SetDamageBar>().ChangeSprite(false);
                setDamageBar_[1].GetComponent<SetDamageBar>().ChangeSprite(false);
                setDamageBar_[2].GetComponent<SetDamageBar>().ChangeSprite(true);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
