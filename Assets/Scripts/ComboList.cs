using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboList : MonoBehaviour {
	public List<Action> deepBreath = new List<Action>();
	public List<Action> standYourGround = new List<Action>();
	public List<Action> flyingKick = new List<Action>();
	public List<Action> uppercut = new List<Action>();


	ActionList ac;
	void Start () {
		ac = GetComponent<ActionList>();

		deepBreath.Add(ac.actionlist[2]);
		deepBreath.Add(ac.actionlist[2]);

		standYourGround.Add(ac.actionlist[2]);
		standYourGround.Add(ac.actionlist[0]);
		standYourGround.Add(ac.actionlist[2]);

		flyingKick.Add(ac.actionlist[2]);
		flyingKick.Add(ac.actionlist[0]);
		flyingKick.Add(ac.actionlist[1]);
		flyingKick.Add(ac.actionlist[5]);

		uppercut.Add(ac.actionlist[2]);
		uppercut.Add(ac.actionlist[3]);
		uppercut.Add(ac.actionlist[0]);
		uppercut.Add(ac.actionlist[4]);

	}
	void Update () {
	}
}
