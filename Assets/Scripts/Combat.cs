using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Combat : MonoBehaviour {
	ActionList ac;
	CreatureList cl;

	public int myComboCost;
	public int myComboAtk;
	public int myComboMov;
	public int myComboTreat;
	public int myComboPower;
	public bool staEnough;
	public Text playerLog;
	public Text creatureLog;
	public Text comboLog;
	public Text mycomboLog;

	public List<Action> mycombo = new List<Action>();

	public void MyComboAddLog()
	{
		comboLog.text = "Action " + mycombo[mycombo.Count - 1].name + " has been added";
		MyComboLog();
	}

	public void MyComboLog()
	{
		mycomboLog.text = " ";
		foreach (Action action in mycombo)
		{
			mycomboLog.text += " " + action.name;
		}
	}

	public void MyComboClear()
	{
		myComboCost = 0;
		myComboAtk = 0;
		myComboMov = 0;
		myComboTreat = 0;
		myComboPower = 0;
		mycombo.Clear();
	}

	public bool StaCheck()
	{
		if(p.staNow > myComboCost)
		{
			staEnough = true;
		}
		if(p.staNow < myComboCost)
		{
			staEnough = false;
		}
		return staEnough;
	}

	public int MyComboSum()
	{
		foreach (Action action in mycombo)
		{
			myComboCost += action.cost;
			myComboAtk += action.atk;
			myComboMov += action.mov;
			myComboTreat += action.treat;
			myComboPower += action.power;

		}
		return myComboCost;
	}

	public void Inputs()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{	
			mycombo.Add(ac.actionlist[0]);
			Debug.Log("Q");
			MyComboAddLog();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			mycombo.Add(ac.actionlist[1]);
			Debug.Log("W");
			MyComboAddLog();

		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			mycombo.Add(ac.actionlist[2]);
			Debug.Log("E");
			MyComboAddLog();

		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			mycombo.Add(ac.actionlist[3]);
			Debug.Log("I");
			MyComboAddLog();

		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			mycombo.Add(ac.actionlist[4]);
			Debug.Log("O");
			MyComboAddLog();

		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			mycombo.Add(ac.actionlist[5]);
			Debug.Log("P");
			MyComboAddLog();

		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//var lastcombo = new List<Action>(mycombo);
			//Debug.Log("Space - combo confirm");
			comboLog.text = "My combo has been cleared";
			MyComboClear();
		}
	}

	public void StatsLog()
	{
		playerLog.text = "Player Stats:" +
			"\nHP: " + p.hpNow + "/" + p.hpMax +
			"\nStamina: " + p.staNow + "/" + p.staMax +
			"\nDefense: " + p.def + " Charge: " + p.charge +
			"\nDodge: " + p.dodge + " Dexterity: " + p.dex;
		creatureLog.text = "Creature Stats:" +
			"\nHP: " + cl.creaturelist[0].hpNow + "/" + cl.creaturelist[0].hpMax +
			"\nAttack: " + cl.creaturelist[0].atk + " Defense: " + cl.creaturelist[0].def +
			"\nDodge: " + cl.creaturelist[0].dodge + " Dexterity: " + cl.creaturelist[0].dex +
			"\nSpeed: " + cl.creaturelist[0].spdNow + "/" + cl.creaturelist[0].spdMax + 
			" Frenesi: " + cl.creaturelist[0].frnsNow + "/" + cl.creaturelist[0].spdMax + 
			"\nReasoning: " + cl.creaturelist[0].rsnNow + "/" + cl.creaturelist[0].rsnMax;
	}

	public Player p = new Player("Bobz", 15, 9, 3, 3, 3, 3);

	void Start ()
	{
		ac = GetComponent<ActionList>();
		cl = GetComponent<CreatureList>();
	}

	void Update ()
	{
		Inputs();
		StatsLog();
	}
}
