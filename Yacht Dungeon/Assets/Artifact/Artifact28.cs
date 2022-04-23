using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact28 : Artifact {

    public override int CalculateBonus(int[] num) {
        int[] c = Sort(num);
        return c[4] - c[0] <= 3 ? 3 : 0;
    }
}
