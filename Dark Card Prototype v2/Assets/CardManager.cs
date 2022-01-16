using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public static CardManager Inst { get; private set; }

    bool isDragging;
    GameObject selectedCard;

    public CardPlayStatus cardPlayStatus;

    public enum CardPlayStatus {
        nothing, // Turn Changed
        canMouseOver, // Enemy's turn
        canMouseDrag // My turn
    }

    void Awake() {
        Inst = this;
    }

    void Start() {
        SetCardPlayStatus();
    }

    public void SetCardPlayStatus() {
        if (TurnManager.Inst.isLoading) {
            cardPlayStatus = CardPlayStatus.nothing;
        } else if (!TurnManager.Inst.isMyTurn) {
            cardPlayStatus = CardPlayStatus.canMouseOver;
        } else {
            cardPlayStatus = CardPlayStatus.canMouseDrag;
        }
    }
}
