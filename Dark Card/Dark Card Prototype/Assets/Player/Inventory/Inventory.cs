using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour {

    private int[] qtys = new int[6];
    public TextMeshProUGUI[] qtyTexts = new TextMeshProUGUI[6];

    private bool isOpen;

    void Start() {
        for (int i = 0; i < qtys.Length; i++) {
            qtys[i] = 0;
        }
        isOpen = false;
        Camera.main.GetComponent<MapCamera>().canMove = true;
        UpdateUI();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (isOpen) {
                Close();
            } else {
                Open();
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            EarnMaterial(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5)) {
            EarnMaterial(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6)) {
            EarnMaterial(2, 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            EarnMaterial(3, 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            EarnMaterial(4, 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            EarnMaterial(5, 1);
        }
    }

    void UpdateUI() {
        for (int i = 0; i < qtyTexts.Length; i++) {
            qtyTexts[i].text = qtys[i].ToString();
        }
    }

    void Open() {
        isOpen = true;
        Camera.main.GetComponent<MapCamera>().canMove = false;
        transform.Translate(new Vector2(-1000, 0));
    }

    void Close() {
        isOpen = false;
        Camera.main.GetComponent<MapCamera>().canMove = true;
        transform.Translate(new Vector2(1000, 0));
    }

    public void EarnMaterial(int index, int qty) {
        qtys[index] += qty;
        UpdateUI();
    }

    public bool PayMaterial(int[] needs) {
        for (int i = 0; i < qtys.Length; i++) {
            if (qtys[i] < needs[i]) {
                return false;
            }
        }

        for (int i = 0; i < qtys.Length; i++) {
            qtys[i] -= needs[i];
        }
        return true;
    }
}
