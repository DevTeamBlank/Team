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

    void RollDice() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == RerollButton.Inst) {
                    RerollButton.Inst.GetComponent<RerollButton>().ChangeSprite(true);
                }
            } else {
                Debug.Log(hit);
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == RerollButton.Inst) {
                    RerollButton.Inst.GetComponent<RerollButton>().ChangeSprite(false);
                    RerollButton.Inst.GetComponent<RerollButton>().RerollSet();
                }
            } else {
                Debug.Log(hit);
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
            } else {
                Debug.Log(hit);
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
            } else {
                Debug.Log(hit);
            }
        }
    }

    void FireDamage() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == FireButton.Inst) {
                    FireButton.Inst.GetComponent<FireButton>().ChangeSprite(true);
                }
            } else {
                Debug.Log(hit);
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == FireButton.Inst) {
                    FireButton.Inst.GetComponent<FireButton>().ChangeSprite(false);
                    FireButton.Inst.GetComponent<FireButton>().FireDamage();
                }
            } else {
                Debug.Log(hit);
            }
        }
    }

    void ResetDamage() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == ResetButton.Inst) {
                    ResetButton.Inst.GetComponent<ResetButton>().ChangeSprite(true);
                }
            } else {
                Debug.Log(hit);
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go == ResetButton.Inst) {
                    ResetButton.Inst.GetComponent<ResetButton>().ChangeSprite(false);
                    ResetButton.Inst.GetComponent<ResetButton>().ResetDamage();
                }
            } else {
                Debug.Log(hit);
            }
        }
    }

    public void RollSet() {
        DiceManager.Inst.RollSet();
        currentRoll++;
        RerollButton.Inst.UpdateDot();
        currentNumbers = DiceManager.Inst.GetNumbers();
        MadeTable.Inst.canSelectMade = true;
        // MadeTable
    }

    [HideInInspector] public RoundStartSubject roundStartS;

    void RoundStart() {
        roundStartS.CallArtifact();
        MadeTable.Inst.RoundStart();
    }

}
