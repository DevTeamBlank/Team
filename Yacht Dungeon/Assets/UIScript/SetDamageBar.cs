using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamageBar : MonoBehaviour {

    [SerializeField] int set_;

    [SerializeField] Sprite selectedSprite_;
    [SerializeField] Sprite normalSprite_;

    [SerializeField] GameObject madeDamageT_;

    private void Update() {
        // SelectSetDamageBar();
    }

    public void ChangeSprite(bool isSelected) {
        if (isSelected) {
            GetComponent<SpriteRenderer>().sprite = selectedSprite_;
        } else {
            GetComponent<SpriteRenderer>().sprite = normalSprite_;
        }
    }

    public int currentDamage;

    public void DamageUpdate(int damage) {
        currentDamage = damage;
        Vector3 pos = madeDamageT_.transform.position;
        TextManager.Inst.ChangeText(damage, madeDamageT_, TextManager.TextMode.Default);
        madeDamageT_.transform.position = pos;
        madeDamageT_.name = "Damage: " + damage.ToString();
    }

    RaycastHit2D hit;
    GameObject target;

    /*
    void SelectSetDamageBar() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == gameObject && AttackManager.Inst.isAttacking) {
                    RoundManager.Inst.ChangeSetDamageBarSprite(set_);
                    AttackManager.Inst.SelectSet(set_, currentDamage);
                }
            }
        }
    }
    */
}
