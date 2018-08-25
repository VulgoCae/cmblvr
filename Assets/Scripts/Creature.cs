using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature {

	public string name;

	public int hpMax, hpNow, atk, def, lvl, dex, dodge;

    public int spdNow, frnsNow, rsnNow, spdMax, frnsMax, rsnMax;
		
	public Creature(string newName, int newHp, int newAtk, int newDef, int newLvl, int newDex, int newDodge, int newSpd, int newFrns, int newRsn) {
		name = newName;
		hpMax = newHp;
		hpNow = newHp;
		atk = newAtk;
		def = newDef;
		lvl = newLvl;
		dex = newDex;
		dodge = newDodge;
        spdNow = 0;
        spdMax = newSpd;
        frnsNow = 0;
        frnsMax = newFrns;
        rsnNow = 0;
        rsnMax = newRsn;

	}
}
