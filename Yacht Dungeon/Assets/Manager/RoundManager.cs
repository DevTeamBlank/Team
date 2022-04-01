using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public static RoundManager Inst { get; private set; }

    public int currentRound;

    [SerializeField] Phase phase;
    [SerializeField] bool canRoll;
    [SerializeField] bool canToggle;

    public enum Phase {
        RoundStart,
        Roll0Set0,
        Toggle0Set0,
        Roll1Set0,
        Toggle1Set0,
        Roll2Set0,
        Toggle2Set0,
        Roll3Set0,
        MadeSet0,
        Roll0Set1,
        Toggle0Set1,
        Roll1Set1,
        Toggle1Set1,
        Roll2Set1,
        Toggle2Set1,
        Roll3Set1,
        MadeSet1,
        Roll0Set2,
        Toggle0Set2,
        Roll1Set2,
        Toggle1Set2,
        Roll2Set2,
        Toggle2Set2,
        Roll3Set2,
        MadeSet2,
        DealDamage,
        Reward,
    }

    void Awake() {
        Inst = this;
    }

    public void StartGame() {
        currentRound = 0;
    }

    [SerializeField] GameObject enemy0;
    [SerializeField] GameObject chest;
    [SerializeField] GameObject enemy1;

    void NextRound() {
        currentRound++;
        phase = Phase.RoundStart;
        GameManager.Inst.SaveGame();       
    }

    public void Load(Save save) {
        currentRound = save.clearedRound;
        phase = Phase.RoundStart;
    }

    RaycastHit2D hit;
    GameObject go;

    void Update() {
        RollDice();
        ToggleDice();       
    }

    void RollSet() {
        if (phase <= Phase.Roll3Set0) {
            DiceManager.Inst.RollSet(0);
        } else if (phase <= Phase.Roll3Set1) {
            DiceManager.Inst.RollSet(1);
        } else if (phase <= Phase.Roll3Set2) {
            DiceManager.Inst.RollSet(2);
        }        
    }

    void RollDice() {
        if (canRoll) {
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
    }

    void ToggleDice() {
        if (canToggle) {
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
    }
    
    void NextPhase() {
        if (phase != Phase.Reward) {
            phase++;
        } else {
            NextRound();
        }
        CanRoll();
        CanToggle();
    }

    void CanRoll() {
        switch (phase) {
            case Phase.Roll0Set0:
            case Phase.Roll1Set0:
            case Phase.Roll2Set0:
            case Phase.Roll3Set0:
            case Phase.Roll0Set1:
            case Phase.Roll1Set1:
            case Phase.Roll2Set1:
            case Phase.Roll3Set1:
            case Phase.Roll0Set2:
            case Phase.Roll1Set2:
            case Phase.Roll2Set2:
            case Phase.Roll3Set2:
                canRoll = true;
                break;
            default:
                canRoll = false;
                break;
        }
    }

    void CanToggle() {
        switch (phase) {
            case Phase.Toggle0Set0:
            case Phase.Toggle1Set0:
            case Phase.Toggle2Set0:
            case Phase.Toggle0Set1:
            case Phase.Toggle1Set1:
            case Phase.Toggle2Set1:
            case Phase.Toggle0Set2:
            case Phase.Toggle1Set2:
            case Phase.Toggle2Set2:
                canToggle = true;
                break;
            default:
                canToggle = false;
                break;
        }
    }
}
