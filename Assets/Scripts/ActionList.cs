using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour {
    public List<Action> actionlist = new List<Action>();
    private void Start() {
                                /* name, atk, cost, mov, treat, complexity */
        actionlist.Add(new Action("Crouch", 0, -1, 0, 0, 0));
        actionlist.Add(new Action("Jump", 2, 2, 2, 1, 2));
        actionlist.Add(new Action("Stand", 0, -2, 0, 0, 0));
        actionlist.Add(new Action("Rush", 3, 2, 2, 1, 1));
        actionlist.Add(new Action("Punch", 2, 2, 0, 0, 1));
        actionlist.Add(new Action("Kick", 93, 3, 0, 1, 2));
        /* foreach (Action action in actionlist) {Debug.Log("Name: " + action.name + " Atk: " + action.atk + " Cost: " + action.cost);}*/
    }

}
