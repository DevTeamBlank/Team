using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueGrit : Card {

    [SerializeField] int armor;
    
    protected override void PlayCard() {
        int applyArmor = Player.Inst.ApplyArmor(armor);
        Player.Inst.GainArmor(applyArmor);

        List<GameObject> hand = CardManager.Inst.GetHand();
        if (hand.Count == 0) { // Hand is empty.
            return;
        }

        int random = Random.Range(0, hand.Count);
        GameObject card = hand[random];
        hand.Remove(card);
        CardManager.Inst.AddExhaustPile(card);
    }
}
