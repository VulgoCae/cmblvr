using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public string name;

    public int hpMax, hpNow, staMax, staNow;

    public int def, dodge, charge, dex;
    
    public Player(string newName, int newHp, int newSta, int newDef, int newDodge, int newCharge, int newDex) {
        name = newName;
        hpMax = newHp;
        hpNow = newHp;
        staMax = newSta;
        staNow = newSta;
        def = newDef;
        dodge = newDodge;
        charge = newCharge;
        dex = newDex;
    }
}
