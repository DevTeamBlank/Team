using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PerfectedStrike : Card {

    [SerializeField] int damage;
    [SerializeField] int extraDamagePerStrike;

    protected override void PlayCard() {
        int count = 0;
        count += CountStrike(CardManager.Inst.GetDrawPile());
        count += CountStrike(CardManager.Inst.GetDiscardPile());
        count += CountStrike(CardManager.Inst.GetHand());

        int addedDamage = damage + extraDamagePerStrike * count;
        int applyDamage = Player.Inst.ApplyDamage(addedDamage);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().GiveDamage(applyDamage, attackType);
    }

    int CountStrike(List<GameObject> list) {
        int count = 0;
        for (int i = 0; i < list.Count; i++) {
            if (list[i].GetComponent<Card>().nomenclature.Contains("Strike")) {
                count++;
            }
        }
        return count;
    }
}
