using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature {

    public string name;

    public int hpMax, hpNow, atk, def, lvl, dex, dodge;
    
    public Creature(string newName, int newHp, int newAtk, int newDef, int newLvl, int newDex, int newDodge) {
        name = newName;
        hpMax = newHp;
        hpNow = newHp;
        atk = newAtk;
        def = newDef;
        lvl = newLvl;
        dex = newDex;
        dodge = newDodge;
    }

}
