using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDamage {

    public int damage;

    public bool trueDamage; // ������, ��, ��� � ���� ����
    public bool penetrateBlock; // �� � ���� ����

    public bool fatal; // ġ��Ÿ ���ʽ�
    public Action fatalAction;

    public ActionDamage(int i, bool b0 = false, bool b1 = false, bool b2 = false, Action a = null) {
        damage = i;
        trueDamage = b0;
        penetrateBlock = b1;
        fatal = b2;
        fatalAction = a;
    }

}
