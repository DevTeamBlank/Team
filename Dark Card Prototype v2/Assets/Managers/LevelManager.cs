using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public enum Status {
        empty,
        aliveEnemy,
        deadEnemy,
        existingArtifact,
        destroyedArtifact
    }

    public GameObject[] entities = new GameObject[8];
    [SerializeField] Status[] statuses = new Status[8];
    [SerializeField] int remainingEnemies;

    public float intervalX; // 나중에 script에 직접 넣을 것.
    public float intervalY;
    public float offsetY;

    float x0, x1, x2, x3, x4;
    float y0, y1, y2;


    public void GiveDamage(int damage, Card.AttackType attackType) {
        switch (attackType) {
            case Card.AttackType.target:
                GiveDamageTarget(damage);
                break;
            case Card.AttackType.all:
                GiveDamageAll(damage);
                break;
            case Card.AttackType.random:
                GiveDamageRandom(damage);
                break;
            case Card.AttackType.notApplicable:
            default:
                Debug.Log("Unvalid attack type.");
                break;
        }
    }

    void GiveDamageTarget(int damage) {
        if (statuses[MousePosition()] == Status.aliveEnemy || statuses[MousePosition()] == Status.existingArtifact) {
            MouseTarget(MousePosition())?.GetComponent<Entity>().TakeDamage(damage);
        } else { // target already dead. (multiple attack)
            return;
        }
    }

    void GiveDamageAll(int damage) {
        for (int i = 0; i < 8; i++) {
            if (IsTargetValid(true, i)) {
                entities[i].GetComponent<Entity>().TakeDamage(damage);
            }
        }
    }

    void GiveDamageRandom(int damage) {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < 8; i++) {
            if (IsTargetValid(true, i)) {
                list.Add(entities[i]);
            }
        }

        if (list.Count == 0) { // No valid target. Already cleared.
            return;
        }

        int random = Random.Range(0, list.Count);
        list[random].GetComponent<Entity>().TakeDamage(damage);
    }

    public void ApplyVulnerable(int duration, Card.AttackType attackType) {
        switch (attackType) {
            case Card.AttackType.target:
                ApplyVulnerableTarget(duration);
                break;
            case Card.AttackType.all:
                ApplyVulnerableAll(duration);
                break;
            case Card.AttackType.random:
            case Card.AttackType.notApplicable:
            default:
                Debug.Log("Unvalid attack type.");
                break;
        }
    }

    void ApplyVulnerableTarget(int duration) {
        if (statuses[MousePosition()] == Status.aliveEnemy || statuses[MousePosition()] == Status.existingArtifact) {
            MouseTarget(MousePosition())?.GetComponent<Entity>().ApplyVulnerable(duration);
        }
    }
    void ApplyVulnerableAll(int duration) {
        for (int i = 0; i < 8; i++) {
            if (IsTargetValid(true, i)) {
                entities[i].GetComponent<Entity>().ApplyVulnerable(duration);
            }
        }
    }

    public void ApplyWeakness(int duration, Card.AttackType attackType) {
        switch (attackType) {
            case Card.AttackType.target:
                ApplyWeaknessTarget(duration);
                break;
            case Card.AttackType.all:
                ApplyWeaknessAll(duration);
                break;
            case Card.AttackType.random:
            case Card.AttackType.notApplicable:
            default:
                Debug.Log("Unvalid attack type.");
                break;
        }
    }

    void ApplyWeaknessTarget(int duration) {
        if (statuses[MousePosition()] == Status.aliveEnemy || statuses[MousePosition()] == Status.existingArtifact) {
            MouseTarget(MousePosition())?.GetComponent<Entity>().ApplyWeakness(duration);
        }
    }
    void ApplyWeaknessAll(int duration) {
        for (int i = 0; i < 8; i++) {
            if (IsTargetValid(true, i)) {
                entities[i].GetComponent<Entity>().ApplyWeakness(duration);
            }
        }
    }

    public void GainStrength(int value, Card.AttackType attackType) {
        switch (attackType) {
            case Card.AttackType.target:
                GainStrengthTarget(value);
                break;
            case Card.AttackType.all:
                GainStrengthAll(value);
                break;
            case Card.AttackType.random:
            case Card.AttackType.notApplicable:
            default:
                Debug.Log("Unvalid attack type.");
                break;

        }
    }

    void GainStrengthTarget(int value) {
        if (statuses[MousePosition()] == Status.aliveEnemy || statuses[MousePosition()] == Status.existingArtifact) {
            MouseTarget(MousePosition())?.GetComponent<Entity>().GainStrength(value);
        }
    }
    void GainStrengthAll(int value) {
        for (int i = 0; i < 8; i++) {
            if (IsTargetValid(true, i)) {
                entities[i].GetComponent<Entity>().GainStrength(value);
            }
        }
    }

    public void Setting() { // DungeonManager가 호출
        LevelSetting();
        Player.Inst.PlayerSetting();
        CardManager.Inst.CardSetting();
        TurnManager.Inst.TurnSetting();        
    }

    public void LevelSetting() {
        GetXYPosition();
        GetStatus();
        EntitySetting();
        // TODO
        // Show UI
    }

    void EntitySetting() {
        for (int i = 0; i < statuses.Length; i++) {
            switch (statuses[i]) {
                case Status.empty:
                    break;
                case Status.aliveEnemy:
                    entities[i].GetComponent<Enemy>().Setting();
                    break;
                case Status.existingArtifact:
                    break;
                default:
                    Debug.Log("Unvalid status.");
                    break;
            }
        }
    }

    int MousePosition() {
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

    void GetXYPosition() {
        Vector2 center = transform.position;

        x2 = center.x;
        x1 = x2 - intervalX;
        x0 = x1 - intervalX;
        x3 = x2 + intervalX;
        x4 = x3 + intervalX;

        y1 = center.y + offsetY;
        y0 = y1 - intervalY;
        y2 = y1 + intervalY;
    }

    void GetStatus() {
        remainingEnemies = 0;
        for (int i = 0; i < entities.Length; i++) {
            if (entities[i] == null) {
                statuses[i] = Status.empty;
            } else if (entities[i].tag == "Enemy") {
                statuses[i] = Status.aliveEnemy;
                remainingEnemies++;
            } else if (entities[i].tag == "Object") {
                statuses[i] = Status.existingArtifact;
            }
        }
    }

    public bool IsTargetValid(bool checkByIndex = false, int index = -1) {
        int target = checkByIndex ? index : MousePosition();

        switch (statuses[target]) {
            case Status.empty:
                return false;
            case Status.aliveEnemy:
                return true;
            case Status.deadEnemy:
                return false;
            case Status.existingArtifact:
                return true;
            case Status.destroyedArtifact:
                return false;
            default:
                Debug.Log("Unvalid status.");
                return false;
        }
    }

    public void EnemyDead(int index) {
        if (statuses[index] != Status.aliveEnemy) Debug.Log("Error");
        statuses[index] = Status.deadEnemy;
        remainingEnemies--;
        CheckLevelClear();
    }

    public void ArtifactDestroyed(int index) {
        if (statuses[index] != Status.existingArtifact) Debug.Log("Error");
        statuses[index] = Status.destroyedArtifact;
    }

    void CheckLevelClear() {
        if (remainingEnemies <= 0) LevelCleared();
    }

    public void LevelCleared() {
        Debug.Log("Level cleared.");
        // TODO
        // Hide UI
        CardManager.Inst.LevelCleared();
        CardDatabase.Inst.LevelCleared();
        CardDatabase.Inst.Reward();
    }

    public void EnemyTurnStart() {
        for (int i = 0; i < entities.Length; i++) {
            if (statuses[i] == Status.aliveEnemy) {
                entities[i].GetComponent<Entity>().TurnStart();
                StartCoroutine(Wait(600));
            }
        }
        for (int i = 0; i < entities.Length; i++) {
            if (statuses[i] == Status.aliveEnemy) {
                entities[i].GetComponent<Entity>().TurnEnd();
            }
        }
        TurnManager.Inst.PlayerTurnStart();
    }

    IEnumerator Wait(float second) {
        yield return new WaitForSeconds(second);
    }

    public Status[] GetStatuses() {
        return statuses;
    }

    public int GetRemainingEnemies() {
        return remainingEnemies;
    }
}
