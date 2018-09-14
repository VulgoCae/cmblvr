using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Combat : MonoBehaviour {
	ActionList ac;
	CreatureList cl;
	ComboList cmbs;
//
	public int myComboCost;
	public int myComboAtk;
	public int myComboMov;
	public int myComboTreat;
	public int myComboPower;
	public Text playerLog;
	public Text creatureLog;
	public Text comboLog;
	public Text mycomboLog;
	public Text combatLog;
	public bool staEnough;
	public bool deepBreath;
	public bool standYourGround;
	public bool flyingKick;
	public bool uppercut;
	public bool canAddAction;
	public bool playerMissed;
//

	public List<Action> mycombo = new List<Action>();
	public List<bool> combosforcheck = new List<bool>();

	public void HPChecker()
	{
		if(cl.creaturelist[0].hpNow <= 0)
		{
			//creature owned
		}
		if(cl.creaturelist[0].hpNow <= 0)
		{
			//game over
		}
	}


	public void TraitsChecker()
	{
		if(cl.creaturelist[0].spdNow >= cl.creaturelist[0].spdMax)
		{
			//creature hits the player
			p.hpNow -= cl.creaturelist[0].atk;
			cl.creaturelist[0].spdNow = 0;
		}
		if(cl.creaturelist[0].rsnNow >= cl.creaturelist[0].rsnMax)
		{
			//creature run away
			cl.creaturelist[0].rsnNow = 0;
		}
		if(cl.creaturelist[0].frnsNow >= cl.creaturelist[0].frnsMax)
		{
			//creature gets buffed
			cl.creaturelist[0].atk += cl.creaturelist[0].atk;
			cl.creaturelist[0].frnsNow = 0;
		}
	}

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
		foreach (Action action in mycombo)
		{
			mycomboLog.text += " " + action.name;
		}
		MyComboSum();
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
		if(deepBreath == true)
		{
			mycomboLog.text = "Deep Breath is ready";
			canAddAction = false;
		}
		if(standYourGround == true)
		{
			mycomboLog.text = "Stand Your Ground is ready";
			canAddAction = false;
		}
		if(flyingKick == true)
		{
			mycomboLog.text = "Flying Kick is ready";
			canAddAction = false;
		}
		if(uppercut == true)
		{
			mycomboLog.text = "Uppercut is ready";
			canAddAction = false;
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
		mycomboLog.text = " ";
	}

	public bool ComboCostCheck()
	{
		if(p.staNow > myComboCost)
		{ staEnough = true; }
		if(p.staNow < myComboCost)
		{ staEnough = false; 
		  combatLog.text = "Not enough stamina.";}
		return staEnough;
	}

	public void MyComboSum()
	{
		foreach (Action action in mycombo)
		{
			myComboCost += action.cost;
			myComboAtk += action.atk;
			myComboMov += action.mov;
			myComboTreat += action.treat;
		}
	}

	public bool MyComboDexChecker()
	{
		if(p.dex >= cl.creaturelist[0].dodge)
		{
			playerMissed = false;
		}
		else playerMissed = true;
		return playerMissed;
	}

	public void Inputs()
	{
		if(canAddAction == true)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				mycombo.Add(ac.actionlist[0]);
				//Debug.Log("Q");
				MyComboAddLog();
			}

			if (Input.GetKeyDown(KeyCode.W))
			{
				mycombo.Add(ac.actionlist[1]);
				//Debug.Log("W");
				MyComboAddLog();
			}

			if (Input.GetKeyDown(KeyCode.E))
			{
				mycombo.Add(ac.actionlist[2]);
				//Debug.Log("E");
				MyComboAddLog();
			}

			if (Input.GetKeyDown(KeyCode.I))
			{
				mycombo.Add(ac.actionlist[3]);
				//Debug.Log("I");
				MyComboAddLog();
			}

			if (Input.GetKeyDown(KeyCode.O))
			{
				mycombo.Add(ac.actionlist[4]);
				//Debug.Log("O");
				MyComboAddLog();
			}

			if (Input.GetKeyDown(KeyCode.P))
			{
				mycombo.Add(ac.actionlist[5]);
				//Debug.Log("P");
				MyComboAddLog();
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//var lastcombo = new List<Action>(mycombo);
			//Debug.Log("Space - combo confirm");
			comboLog.text = "Combo has been cleared";
			MyComboClear();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			MyComboSum();
			ComboCostCheck();
			if(deepBreath == true)
			{
				MyComboCalc();
			}
			if(standYourGround == true)
			{
				MyComboCalc();
			}
			if(flyingKick == true)
			{
				MyComboCalc();
			}
			if(uppercut == true)
			{
				MyComboCalc();
			}
			TraitsChecker();
			Debug.Log("C");
		}
	}

	public void StatsLog()
	{
		playerLog.text = "Player Stats:" +
			"\nHP: " + p.hpNow + "/" + p.hpMax +
			"\nStamina: " + p.staNow + "/" + p.staMax +
			"\nDefense: " + p.def + "\nDodge: " + p.dodge + " Dexterity: " + p.dex + 
			"\nCan add action: " + canAddAction;
		creatureLog.text = "Creature Stats:" +
			"\nHP: " + cl.creaturelist[0].hpNow + "/" + cl.creaturelist[0].hpMax +
			"\nAttack: " + cl.creaturelist[0].atk + " Defense: " + cl.creaturelist[0].def +
			"\nDodge: " + cl.creaturelist[0].dodge + " Dexterity: " + cl.creaturelist[0].dex +
			"\nSpeed: " + cl.creaturelist[0].spdNow + "/" + cl.creaturelist[0].spdMax + 
			" Frenesi: " + cl.creaturelist[0].frnsNow + "/" + cl.creaturelist[0].spdMax + 
			"\nReasoning: " + cl.creaturelist[0].rsnNow + "/" + cl.creaturelist[0].rsnMax;
	}

	public void CombatLog()
	{
		combatLog.text = "Combo cost:\nStamina: " + myComboCost + " Attack: " + myComboAtk + " Treat: " + myComboTreat + " Mov: " + myComboMov +
							" Power: " + myComboPower + "\nDB: " + deepBreath + " SYG: " + standYourGround + " FK: " + flyingKick + " UC: " + uppercut;
	}

	public void MyComboCalc()
	{
		if(staEnough == true)
		{
			MyComboDexChecker();
			if(playerMissed == false)
			{
				cl.creaturelist[0].hpNow -= myComboAtk;
				cl.creaturelist[0].rsnNow += myComboTreat;
				cl.creaturelist[0].frnsNow += myComboTreat;
				if(myComboMov <= cl.creaturelist[0].spdNow)
				{
					cl.creaturelist[0].spdNow += 1;
				}
				p.dodge = myComboMov;
				p.staNow += myComboCost;
				if(p.staNow > p.staMax)
				{
					p.staNow = p.staMax;
				}
				MyComboClear();
			}
		}
	}

	public Player p = new Player("Bobz", 15, 9, 3, 3, 3);

	void Start ()
	{
		ac = GetComponent<ActionList>();
		cl = GetComponent<CreatureList>();
		cmbs = GetComponent<ComboList>();
		canAddAction = true;
		combosforcheck.Add(deepBreath);
		combosforcheck.Add(standYourGround);
		combosforcheck.Add(flyingKick);
		combosforcheck.Add(uppercut);
	}

	void Update ()
	{
		Inputs();
		StatsLog();
		ComboListChecker();
		MyComboLog();
		CombatLog();
		HPChecker();
	}
}
