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

    public PRS originalPRS;

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

    public void Order(int order) {
        Renderer renderer = GetComponent<SpriteRenderer>();
        renderer.sortingLayerName = "Card";
        renderer.sortingOrder = order * 10;
    }

    public void Tag() {
        gameObject.tag = "Card";
    }

    public static int ID(GameObject card) {
        return card.GetComponent<Card>() == null ? -1 : card.GetComponent<Card>().CardID;
    }

    public void SavePRS() {
        originalPRS = new PRS(transform);
    }

    public void LoadPRS() {
        originalPRS.Apply(transform);
    }

}
