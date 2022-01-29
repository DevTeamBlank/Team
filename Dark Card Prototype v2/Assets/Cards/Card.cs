using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    [SerializeField] int CardID;
    public string nomenclature;

    public int GetCardID() {
        return CardID;
    }

    [SerializeField] Rarity rarity;
    [SerializeField] protected int energy;

    public enum Rarity {
        starter,
        common,
        uncommon,
        rare,
        status,
        curse
    }

    public Rarity GetRarity() {
        return rarity;
    }

    [SerializeField] protected AttackType attackType;

    public enum AttackType {
        notApplicable,
        target,
        random,
        all
    }

    [SerializeField] protected CardType cardType;

    public enum CardType {
        notApplicable,
        attack,
        skill
    }

    public CardType GetCardType() {
        return cardType;
    }

    [SerializeField] protected bool isExhaust = false;

    public bool GetIsExhaust() {
        return isExhaust;
    }

    [SerializeField] protected bool isEthereal = false;

    public bool GetIsEthereal() {
        return isEthereal;
    }

    [SerializeField] protected bool isPlayable = true;

    public void Play() {
        if (IsPlayble()) {
            UseEnergy();
            PlayCard(); // virtual
            CardManager.Inst.Played(gameObject);
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
        Player.Inst.UseEnergy(energy);
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
