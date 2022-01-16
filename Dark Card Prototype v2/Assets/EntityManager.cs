using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

    public enum Status {
        empty,
        alive,
        dead
    }

    public GameObject[] entities = new GameObject[8];
    [SerializeField] Status[] statuses = new Status[8];

    public float intervalX; // 나중에 script에 직접 넣을 것.
    public float intervalY;
    public float offsetY;

    float x0, x1, x2, x3, x4;
    float y0, y1, y2;

    [SerializeField] int remainingEntities;

    void Start() {

    }

    public void GiveDamage() {
        // MouseTarget(MousePosition())?.GetComponent<Entity>().
    }

    public void Setting() { // DungeonManager가 호출
        Vector2 center = Camera.main.transform.position;

        x2 = center.x;
        x1 = x2 - intervalX;
        x0 = x1 - intervalX;
        x3 = x2 + intervalX;
        x4 = x3 + intervalX;

        y1 = center.y + offsetY;
        y0 = y1 - intervalY;
        y2 = y1 + intervalY;
    }

    int MousePosition() {
        Vector2 temp = Camera.main.WorldToScreenPoint(Input.mousePosition);
        float x = temp.x;
        float y = temp.y;

        int ret = 0;
        if (x < x0) {
            return -1;
        } else if (x < x1) {
            ret += 0;
        } else if (x < x2) {
            ret += 1;
        } else if (x < x3) {
            ret += 2;
        } else if (x < x4) {
            ret += 3;
        } else { // (x4 <= x)
            return -1;
        }

        if (y < y0) {
            return -1;
        } else if (y < y1) {
            ret += 0;
        } else if (y < y2) {
            ret += 4;
        } else { // (y2 < y)
            return -1;
        }

        return ret;
    }

    GameObject MouseTarget(int index) {
        if (index == -1) return null;
        return entities[index];
    }

    void CheckStatus() {

    }
    void EntityDead(int index) {

    }

}
