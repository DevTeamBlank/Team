using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

    public static TextManager Inst { get; private set; }

    void Awake() {
        Inst = this;
    }

    public enum TextMode {
        Default,
        OnMouse,
        Used
    }

    [SerializeField] Sprite[] default_ = new Sprite[10];
    [SerializeField] Sprite[] onMouse_ = new Sprite[10];
    [SerializeField] Sprite[] used_ = new Sprite[10];
    [SerializeField] int[] width_ = new int[10]; // 3, 4
    [SerializeField] GameObject emptyPrefab_;
    GameObject[] sprites;

    public GameObject SpriteToString(int number, Transform parent, TextMode mode) {
        GameObject ret = Instantiate(emptyPrefab_, parent);
        string str = number.ToString();
        char[] chs = new char[str.Length];
        sprites = new GameObject[str.Length];
        for (int i = 0; i < sprites.Length; i++) {
            sprites[i] = Instantiate(NumberToGameObject(chs[i], mode), ret.transform);
        }
        float offset = 0f;
        for (int i = 0; i < sprites.Length; i++) {
            sprites[i].transform.Translate(new Vector2(offset, 0f));
            offset += (NumberToWidth(chs[i]) + 1) * 0.06f;
        }
        ret.name = number.ToString();
        return ret;
    }

    int NumberToWidth(char i) {
        int num = i - '0';
        return width_[num];
    }

    GameObject NumberToGameObject(char i, TextMode mode) {
        int num = i - '0';
        switch (mode) {
            case TextMode.Default:
                GameObject ret0 = Instantiate(emptyPrefab_);
                ret0.name = i.ToString();
                ret0.AddComponent<SpriteRenderer>();
                ret0.GetComponent<SpriteRenderer>().sprite = default_[num];
                return ret0;
            case TextMode.OnMouse:
                GameObject ret1 = Instantiate(emptyPrefab_);
                ret1.name = i.ToString();
                ret1.AddComponent<SpriteRenderer>();
                ret1.GetComponent<SpriteRenderer>().sprite = onMouse_[num];
                return ret1;
            case TextMode.Used:
                GameObject ret2 = Instantiate(emptyPrefab_);
                ret2.name = i.ToString();
                ret2.AddComponent<SpriteRenderer>();
                ret2.GetComponent<SpriteRenderer>().sprite = used_[num];
                return ret2;
            default:
                Debug.Log("Error");
                GameObject ret3 = Instantiate(emptyPrefab_);
                ret3.name = i.ToString();
                ret3.AddComponent<SpriteRenderer>();
                ret3.GetComponent<SpriteRenderer>().sprite = default_[num];
                return ret3;
        }
    }
}
