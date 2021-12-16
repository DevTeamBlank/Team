using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Nickname : MonoBehaviour {

    public string nickname;

    void Start() {
        GetComponent<TextMeshProUGUI>().text = nickname;
    }
}
