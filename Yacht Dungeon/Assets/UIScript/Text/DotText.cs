using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotText : MonoBehaviour {

    [SerializeField] static GameObject[] dots_ = new GameObject[38]; // 0~25: 'A'~'Z', 26~35: '0'~'9', 36: '+', 37: '.'
    [SerializeField] static int[] width_ = new int[38]; // 3, 4
    [SerializeField] GameObject emptyPrefab_;
    GameObject[] sprites;

    public GameObject SpriteToString(string str, Transform parent) {
        GameObject ret = Instantiate(emptyPrefab_, parent);
        sprites = new GameObject[str.Length];
        char[] chs = str.ToCharArray();
        for (int i = 0; i < chs.Length; i++) {
            sprites[i] = Instantiate(CharToGameObject(chs[i]), ret.transform);
        }
        float offset = 0f;
        for (int i = 0; i < chs.Length; i++) {
            sprites[i].transform.Translate(new Vector2(offset, 0f));
            offset += (CharToWidth(chs[i]) + 1) * 0.06f;
        }

        return ret;
    }

    int CharToWidth(char ch) {
        if ('A' <= ch && ch <= 'Z') {
            return width_[ch - 'A'];
        } else if ('0' <= ch && ch <= '+') {
            return width_[ch - '0' + 26];
        } else if (ch == '.') {
            return width_[37];
        } else {
            return -1;
        }
    }

    GameObject CharToGameObject(char ch) {
        if ('A' <= ch && ch <= 'Z') {
            return dots_[ch - 'A'];
        } else if ('0' <= ch && ch <= '+') {
            return dots_[ch - '0' + 26];
        } else if (ch == '.'){
            return dots_[37];
        } else {
            return null;
        }
    }
}
