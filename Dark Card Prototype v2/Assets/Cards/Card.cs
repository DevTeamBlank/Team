using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    [SerializeField] int CardID;
    [SerializeField] string nomenclature;

    [SerializeField] Rarity rarity;
    [SerializeField] int energy;

    public enum Rarity {
        starter,
        common,
        uncommon,
        rare
    }

    [SerializeField] AttackType attackType;

    public enum AttackType {
        nan,
        target,
        random,
        all
    }

    [SerializeField] bool playable = true;

    protected void Play() {
        if (IsPlayble()) {
            UseEnergy();
            PlayCard(); // virtual
            // TODO
            // DiscardPile로 이동
        } else {
            // 카드 제자리로
        }
    }

    protected virtual void PlayCard() { }

    protected bool IsPlayble() {
        if (CardManager.Inst.cardPlayStatus != CardManager.CardPlayStatus.canMouseDrag) {
            Debug.Log("Not my turn.");
            return false; // Not my turn
        }
        if (!playable) {
            Debug.Log("Unplayble card.");
            return false;
        }
        if (Player.Inst.energy < energy) {
            Debug.Log("Not enough energy.");
            return false;
        }
        return true;
    }

    protected void UseEnergy() {
        Player.Inst.energy -= energy;
    }

    public void Order() {
        // TODO
    }

}
