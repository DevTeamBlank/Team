using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public readonly int CardID;
    public readonly string nomenclature;
    public readonly Rarity rarity;
    public readonly TargetType targetType;
    public readonly CardType cardType;

    public int energy;

    public enum Rarity {
        // TODO
    }
    public enum TargetType {
        notApplicable,
        target,
        random,
        all
    }    
    public enum CardType {
        attack,
        skill,
        // TODO
    }

    public bool isExhaust = false;
    public bool isEthereal = false;
    public bool isPlayable = true;

    public void Play() {
        if (IsPlayble()) {
            CardManager.Inst.Played(gameObject);
            UseEnergy();
            PlayCard(); // virtual
        } else {
            return;
        }
    }

    protected virtual void PlayCard() {
        Debug.Log("Card Description not implemented.");
    }

    protected virtual bool IsPlayble() {
        if (CardManager.Inst.cardPlayStatus != CardManager.CardPlayStatus.canPlay) {
            Debug.Log("Not my turn.");
            return false;
        }
        if (!isPlayable) {
            Debug.Log("Unplayble card.");
            return false;
        }
        if (Player.Inst.energy < energy) {
            Debug.Log("Not enough energy.");
            return false;
        }
        if (attackType == AttackType.target && !GameObject.Find("LevelManager").GetComponent<LevelManager>().IsTargetValid()) {
            Debug.Log("Unvalid target.");
            return false;
        }
        return true;
    }

    protected void UseEnergy() {

    }

    public virtual void TurnEnd() {

    }
    public virtual void Drawn() {

    }

    public void Order(int order) {
        Renderer renderer = GetComponent<SpriteRenderer>();
        renderer.sortingLayerName = "Card";
        renderer.sortingOrder = order * 10;
    }

}
