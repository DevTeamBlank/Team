using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public static CardManager Inst { get; private set; }

    public DrawPile drawPile;
    public DiscardPile discardPile;
    public HandPile handPile;
    public ExhaustPile exhaustPile;

    void Awake() {
        Inst = this;
    }

    

}
