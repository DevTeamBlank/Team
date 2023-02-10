using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

    private GameObject _gameObject;
    public int buffType;
    private int Value { get; set; }

    public enum BuffType { // Regenereation: 3
        NaN = 0,
        Intensity = 1,
        Duration = 2,
        Counter = 4
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Attach(GameObject gameObject) {
        _gameObject = gameObject;

    }

    // Utilize Overriding!
    protected void Activate() {

    }

    protected void BattleStart() {

    }

    protected void TurnStart() {

    }

    protected void TurnEnd() {

    }

    protected void BattleEnd() {

    }

}
