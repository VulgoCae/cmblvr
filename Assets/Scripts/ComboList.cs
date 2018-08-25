using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboList : MonoBehaviour {
	public List<Action> deepBreath = new List<Action>();
	ActionList ac;
	void Start () {
		ac = GetComponent<ActionList>();
		deepBreath.Add(ac.actionlist[2]);
		deepBreath.Add(ac.actionlist[2]);
		Debug.Log("DeepBreath: " + deepBreath[0] + deepBreath[1]);
		
	}
	void Update () {
		
	}
}
