using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] Sprite[] sprites_ = new Sprite[3];
    [SerializeField] GameObject[] attacks_ = new GameObject[3];

    public Direction currentDirection = Direction.center;


    public enum Direction {
        center,
        right,
        rightRight
    }

    public void WeaponReset() {
        ChangeSprite(Direction.center);
    }

    public void ChangeSprite (Direction direction){
        currentDirection = direction;
        GetComponent<SpriteRenderer>().sprite = sprites_[(int)currentDirection];
    }

}
