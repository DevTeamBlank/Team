using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningPact : Card {

    [SerializeField] int draw;

    protected override void PlayCard() {
        List<GameObject> hand = CardManager.Inst.GetHand();
        if (hand.Count == 0) { // Hand is empty.
            return;
        }

        int random = Random.Range(0, hand.Count);
        GameObject card = hand[random];
        hand.Remove(card);
        CardManager.Inst.HandUpdate();
        CardManager.Inst.AddExhaustPile(card);

        CardManager.Inst.DrawCards(draw);
    }
}
