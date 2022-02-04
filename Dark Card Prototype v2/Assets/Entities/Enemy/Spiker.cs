using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spiker : Enemy {

    [SerializeField] int thorns = 3;
    [SerializeField] int spike = 0;
    [SerializeField] int maxSpike = 6;

    protected override void DecidePattern() {
        if (spike < maxSpike    ) {
            currPattern = Random.Range(0, patterns);
        } else {
            currPattern = 1;
        }
        UpdateIntent(intents[currPattern]);
        UpdateDamage(damages[currPattern]);
        UpdateThorns();
    }

    public override void Patterns(int index) {
        switch (index) {
            case 0:
                Pattern0();
                break;
            case 1:
                Pattern1();
                break;
        }
    }

    public void Pattern0() {
        int damage = ApplyDamage(damages[0]);
        Player.Inst.TakeDamage(damage);

    }
    public void Pattern1() {
        thorns += 2;
        spike++;
        UpdateThorns();
    }

    public override void TakeDamage(int value) {
        base.TakeDamage(value);
        Player.Inst.TakeDamage(thorns);
    }

    void UpdateThorns() {
        transform.Find("ThornsUI").GetComponent<TextMeshPro>().text = thorns.ToString();
    }

}
