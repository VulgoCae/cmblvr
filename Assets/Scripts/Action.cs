using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    public string name;
    public int atk, cost, mov, treat, complexity;
    public Action(string newName, int newAtk, int newCost, int newMov, int newTreat, int newComplexity) {
        name = newName;
        atk = newAtk;
        cost = newCost;
        mov = newMov;
        treat = newTreat;
        complexity = newComplexity;
    }
}
