﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureList : MonoBehaviour {

	public List<Creature> creaturelist = new List<Creature>();
	
	void Start () {
//	name, hp, atk, def, lvl, dex, dodge
		creaturelist.Add(new Creature("Luzhir", 15, 4, 3, 1, 3, 3, 3, 3, 3 ));
		creaturelist.Add(new Creature("Quazhir", 30, 6, 3, 1, 3, 3, 3, 3, 3 ));
		creaturelist.Add(new Creature("Quazhir", 45, 8, 3, 1, 3, 3, 3, 3, 3 ));
	}
}
