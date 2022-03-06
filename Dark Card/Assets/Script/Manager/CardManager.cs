using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public static CardManager Inst { get; private set; }

    [SerializeField] GameObject drawPile_;
    [SerializeField] GameObject discardPile_;
    [SerializeField] GameObject handPile_;
    [SerializeField] GameObject exhaustPile_;

    DrawPile drawPile;
    DiscardPile discardPile;
    HandPile handPile;
    ExhaustPile exhaustPile;

    enum Index {
        DrawPile,
        DiscardPile,
        HandPile,
        ExhaustPile
    }

    void GetComponent() {
        drawPile = drawPile_.GetComponent<DrawPile>();
        discardPile = discardPile_.GetComponent<DiscardPile>();
        handPile = handPile_.GetComponent<HandPile>();
        exhaustPile = exhaustPile_.GetComponent<ExhaustPile>();
    }

    void Awake() {
        Inst = this;
    }

    void Add(GameObject card, Index index) {
        switch (index) {
            case Index.DrawPile:
                card.transform.parent = drawPile_.transform;
                drawPile.Add(card);
                break;
            case Index.DiscardPile:
                card.transform.parent = discardPile_.transform;
                discardPile.Add(card);
                break;
            case Index.HandPile:
                card.transform.parent = handPile_.transform;
                handPile.Add(card);
                break;
            case Index.ExhaustPile:
                card.transform.parent = exhaustPile_.transform;
                exhaustPile.Add(card);
                break;
        }
    }

    void Remove(GameObject card, Index index) {
        switch (index) {
            case Index.DrawPile:
                drawPile.Remove(card);
                break;
            case Index.DiscardPile:
                discardPile.Remove(card);
                break;
            case Index.HandPile:
                handPile.Remove(card);
                break;
            case Index.ExhaustPile:
                exhaustPile.Remove(card);
                break;
        }
    }

    GameObject Pop(Index index) {
        switch (index) {
            case Index.DrawPile:
                return drawPile.Pop();
                break;
            case Index.DiscardPile:
                return discardPile.Pop();
                break;
            case Index.HandPile:
                return handPile.Pop();
                break;
            case Index.ExhaustPile:
                return exhaustPile.Pop();
                break;
        }
        return null;
    }

}
