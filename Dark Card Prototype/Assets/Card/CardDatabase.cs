using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour {

    public int maxCardID;
    private int maxCard;

    private int[,] deckList;

    void Start() {
        DontDestroyOnLoad(gameObject);

        maxCard = maxCardID + 1;

        deckList = new int[maxCard, 3];
        for (int i = 0; i < deckList.Length; i++) {
            deckList[i, 0] = 0;
            deckList[i, 1] = 0;
            deckList[i, 2] = 0;
        }

    }

    void Update() {

    }
}
