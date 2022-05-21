using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public static RoundManager Inst { get; private set; }

    public int currentRound;
    public int currentSet;
    public int currentRoll;
    public int[] currentNumbers = new int[5];

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        currentRound = 0;
        currentSet = 1;
        currentRoll = 0;
    }

    [SerializeField] GameObject enemy0;
    [SerializeField] GameObject chest;
    [SerializeField] GameObject enemy1;

    public int set1Damage;
    public int set2Damage;
    public int set3Damage;


    public void Load(Save save) {
        currentRound = save.clearedRound;
        currentSet = 1;
        currentRoll = 0;
    }

    RaycastHit2D hit;
    GameObject go;

    void Update() {
        RollDice();
        ToggleDice();
        TriggerDice();
        FireDamage();
        ResetDamage();
    }

    [SerializeField] GameObject rerollButton_;

    void RollDice() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == rerollButton_) {
                    RerollButton.Inst.GetComponent<RerollButton>().ChangeSprite(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == rerollButton_) {
                    RerollButton.Inst.GetComponent<RerollButton>().ChangeSprite(false);
                    RerollButton.Inst.GetComponent<RerollButton>().RerollSet();
                }
            }
        }
    }

    void ToggleDice() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go.tag == "Dice") {
                    go.GetComponent<Dice>().ToggleFixDice();
                }
            }
        }
    }

    void TriggerDice() {
        if (Input.GetMouseButtonDown(1)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go.tag == "Dice") {
                    go.GetComponent<Dice>().TriggerDice();
                }
            }
        }
    }

    [SerializeField] GameObject fireButton_;
    [SerializeField] GameObject resetButton_;

    void FireDamage() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == fireButton_) {
                    FireButton.Inst.GetComponent<FireButton>().ChangeSprite(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == fireButton_) {
                    FireButton.Inst.GetComponent<FireButton>().ChangeSprite(false);
                    FireButton.Inst.GetComponent<FireButton>().FireDamage();
                }
            }
        }
    }

    void ResetDamage() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == resetButton_) {
                    ResetButton.Inst.GetComponent<ResetButton>().ChangeSprite(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == resetButton_) {
                    ResetButton.Inst.GetComponent<ResetButton>().ChangeSprite(false);
                    ResetButton.Inst.GetComponent<ResetButton>().ResetDamage();
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
        roundStartS.CallArtifact();
    }

}
