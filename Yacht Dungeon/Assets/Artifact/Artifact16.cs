using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact16 : Artifact { 

    public override int CalculateBonus(int[] num) {
        return Kinds(GetIndex());
    }

}
