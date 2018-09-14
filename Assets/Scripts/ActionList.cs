using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour {

	public List<Action> actionlist = new List<Action>();

	private void Awake() {
		actionlist.Add(new Action("Crouch", 0, -1, -1, 1));
		actionlist.Add(new Action("Jump", 1, 2, 2, 1));
		actionlist.Add(new Action("Stand", 0, -2, -1, 0));
		actionlist.Add(new Action("Rush", 2, 2, 2, 1));
		actionlist.Add(new Action("Punch", 2, 2, 0, 0));
		actionlist.Add(new Action("Kick", 3, 3, 0, 1));
	}
}
