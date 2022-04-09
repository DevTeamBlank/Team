using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour {

    [SerializeField] bool isEnabled;

    public int index_;
    public string nomenclature_;
    public ArtifactType type_;
    public ArtifactRarity rarity_;
    public string description_;

    public enum ArtifactRarity {
        Basic,
        Common,
        Uncommon,
        Rare
    }

    public enum ArtifactType {
        Made,
        Set,
        Update
    }

    public void Enable() {
        isEnabled = true;
        switch (type_) {
            case ArtifactType.Made:
                EnableMade();
                break;
            case ArtifactType.Set:
                EnableSet();
                break;
            case ArtifactType.Update:
                EnableUpdate();
                break;
        }
    }

    public virtual void EnableMade() {

    }

    public virtual void EnableSet() {
        Observer o = new Observer(this);
        o.AddSubject(MadeTable.Inst.setS);
    }

    public virtual void EnableUpdate() {

    }

    public virtual int CalculateBonus(int[] num) {
        return 0;
    }


}
