using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save {
    
    public int seed;
    public int hp;
    public int clearedRound;
    public int choice;
    public List<int> artifact;

    public int[] set1 = new int[5];
    public int[] set2 = new int[5];
    public int[] set3 = new int[5];

    public Save (int seed, int hp, int clearedRound, int choice, List<int> artifact, int[] set1, int[] set2, int[] set3) {
        this.seed = seed;
        this.hp = hp;
        this.clearedRound = clearedRound;
        this.choice = choice;
        this.artifact = artifact;

        this.set1 = set1;
        this.set2 = set2;
        this.set3 = set3;
    }
    
    public void MakeFile() {
        // TODO
    }
}

