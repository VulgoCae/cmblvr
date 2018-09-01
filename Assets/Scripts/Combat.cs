using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Combat : MonoBehaviour {
	ActionList ac;
	CreatureList cl;
	ComboList cmbs;

	public int myComboCost;
	public int myComboAtk;
	public int myComboMov;
	public int myComboTreat;
	public int myComboPower;
	public Text playerLog;
	public Text creatureLog;
	public Text comboLog;
	public Text mycomboLog;
	public bool staEnough;
	public bool deepBreath;
	public bool standYourGround;
	public bool flyingKick;
	public bool uppercut;
	public bool canAddAction;
	public List<Action> mycombo = new List<Action>();
	public void ComboListChecker()
	{
		deepBreath = mycombo.SequenceEqual(cmbs.deepBreath);
		standYourGround = mycombo.SequenceEqual(cmbs.standYourGround);
		flyingKick = mycombo.SequenceEqual(cmbs.flyingKick);
		uppercut = mycombo.SequenceEqual(cmbs.uppercut);

	}

	public void MyComboAddLog()
	{
		comboLog.text = "Action " + mycombo[mycombo.Count - 1].name + " has been added";
		MyComboLog();
	}

	public bool ActionCostChecker(int energy, int stamina)
	{
		if(energy <= stamina)
		{
			return true;
		}
		else return false;
	}

	public void MyComboLog()
	{
		mycomboLog.text = " ";

		if(deepBreath == true)
		{
			mycomboLog.text += "\nDeep Breath is ready";
			canAddAction = false;
		}
		if(standYourGround == true)
		{
			mycomboLog.text += "\nStand Your Ground is ready";
			canAddAction = false;
		}
		if(flyingKick == true)
		{
			mycomboLog.text += "\nFlying Kick is ready";
			canAddAction = false;
		}
		if(uppercut == true)
		{
			mycomboLog.text += "\nUppercut is ready";
			canAddAction = false;
		}


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
		deepBreath = false;
		standYourGround = false;
		flyingKick = false;
		uppercut = false;
		canAddAction = true;
	}

	public bool ComboCostCheck()
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

	public void MyComboDexChecker()
	{
		
	}

	public void Inputs()
	{
		if(canAddAction == true)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{	
				if(ActionCostChecker(ac.actionlist[0].cost, p.staNow))
				{
					mycombo.Add(ac.actionlist[0]);
					if(p.staNow < p.staMax)
					{
						p.staNow -= ac.actionlist[0].cost;
					}
				}
				else mycomboLog.text = "Not enough stamina";
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
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//var lastcombo = new List<Action>(mycombo);
			//Debug.Log("Space - combo confirm");
			comboLog.text = "My combo has been cleared";
			MyComboClear();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			MyComboSum();
			ComboCostCheck();
			if(staEnough == true)
			{
				cl.creaturelist[0].hpNow -= myComboAtk;
				cl.creaturelist[0].rsnNow += myComboTreat;
				cl.creaturelist[0].spdNow += myComboPower;
				cl.creaturelist[0].frnsNow += myComboTreat;
				
				p.dodge = myComboMov;
				p.staNow -= myComboCost;
				if(p.staNow > p.staMax)
				{
					p.staNow = p.staMax;
				}
				MyComboClear();
			}
			Debug.Log("C");
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
		cmbs = GetComponent<ComboList>();
		canAddAction = true;
	}

	void Update ()
	{
		Inputs();
		StatsLog();
		ComboListChecker();
	}
}
