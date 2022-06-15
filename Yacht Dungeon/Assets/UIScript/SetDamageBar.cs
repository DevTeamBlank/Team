using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamageBar : MonoBehaviour {

    [SerializeField] Sprite selectedSprite_;
    [SerializeField] Sprite normalSprite_;

    [SerializeField] GameObject madeDamageT_;

    public void ChangeSprite(bool isSelected) {
        if (isSelected) {
            GetComponent<SpriteRenderer>().sprite = selectedSprite_;
        } else {
            GetComponent<SpriteRenderer>().sprite = normalSprite_;
        }
    }

    public void DamageUpdate(int damage) {
        Vector3 pos = madeDamageT_.transform.position;
        TextManager.Inst.ChangeText(damage, madeDamageT_, TextManager.TextMode.Default);
        madeDamageT_.transform.position = pos;
        madeDamageT_.name = "Damage: " + damage.ToString();
    }
}
