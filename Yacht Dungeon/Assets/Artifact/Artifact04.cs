using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact04 : Artifact {

    public override int CalculateBonus(int[] num) {
        return Kinds(num);
    }

}
