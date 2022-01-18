using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card05 : Card {

    [SerializeField] int damage;

    protected override void PlayCard() {
        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
    protected override bool IsPlayble() {

        for (int i = 0; i<CardManager.Inst.GetHand().Count; i++) {
            if (CardManager.Inst.GetHand()[i].GetComponent<Card>().GetCardType() != CardType.attack) {
                Debug.Log("There is a non-attack card.");
                return false;
            }
        }

        if (CardManager.Inst.cardPlayStatus != CardManager.CardPlayStatus.canMouseDrag) {
            Debug.Log("Not my turn.");
            return false;
        }
        if (!playable) {
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
}
