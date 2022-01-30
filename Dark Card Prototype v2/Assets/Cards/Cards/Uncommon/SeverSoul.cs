using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeverSoul : Card {

    [SerializeField] int damage;

    protected override void PlayCard() {
        List<GameObject> hand = CardManager.Inst.GetHand();
        List<GameObject> nonAttackCards = new List<GameObject>();
        for (int i = 0; i < hand.Count; i++) {
            if (hand[i].GetComponent<Card>().GetCardType() != CardType.attack) {
                nonAttackCards.Add(hand[i]);
            }
        }
        for (int i = 0; i < nonAttackCards.Count; i++) {
            hand.Remove(nonAttackCards[i]);
            CardManager.Inst.AddExhaustPile(nonAttackCards[i]);
        }
        CardManager.Inst.HandUpdate();

        int applyDamage = Player.Inst.ApplyDamage(damage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }
}
