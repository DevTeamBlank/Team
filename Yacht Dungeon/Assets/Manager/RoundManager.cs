using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public static RoundManager Inst { get; private set; }

    public int currentRound;
    public int currentSet;
    public int[] currentNumbers = new int[5];

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        currentRound = 0;
    }

    [SerializeField] GameObject enemy0;
    [SerializeField] GameObject chest;
    [SerializeField] GameObject enemy1;


    public void Load(Save save) {
        currentRound = save.clearedRound;
    }

    RaycastHit2D hit;
    GameObject go;

    void Update() {
        RollDice();
        ToggleDice();
        TriggerDice();
    }

    void RollDice() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f);

            if (hit) {
                go = hit.transform.gameObject;
                if (go.tag == "RollButton") {
                    RollSet();
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

    void RollSet() {
        DiceManager.Inst.RollSet();
        currentNumbers = DiceManager.Inst.GetNumbers();
        // MadeTable
    }
}
