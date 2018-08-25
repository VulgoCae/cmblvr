using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Combat : MonoBehaviour {

	ActionList ac;
	public int myComboCost;
	public int myComboAtk;
	public int myComboMov;
	public int myComboTreat;
	public int myComboPower;
	public bool staEnough;

	public List<Action> mycombo = new List<Action>();

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
		if(player.staNow > myComboCost)
		{
			staEnough = true;
		}
		if(player.staNow < myComboCost)
		{
			staEnough = false;
		}
		return staEnough;
	}

	// name, hp, sta, def, dodge, dex
	public Player player = new Player("Bobz", 15, 9, 3, 3, 3);

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

	public void MyComboLog(){
		Debug.Log("Actions in mycombo list:");
			foreach (Action action in mycombo) {
				Debug.Log("Name: " + action.name + " Atk: " + action.atk + " Cost: " + action.cost);}}

	public void Inputs(){
		if (Input.GetKeyDown(KeyCode.Q))
		{	
			mycombo.Add(ac.actionlist[0]);
			Debug.Log("Q");
			MyComboLog();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			mycombo.Add(ac.actionlist[1]);
			Debug.Log("W");
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			mycombo.Add(ac.actionlist[2]);
			Debug.Log("E");
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			mycombo.Add(ac.actionlist[3]);
			Debug.Log("I");
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			mycombo.Add(ac.actionlist[4]);
			Debug.Log("O");
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			mycombo.Add(ac.actionlist[5]);
			Debug.Log("P");
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//var lastcombo = new List<Action>(mycombo);
			//Debug.Log("Space - combo confirm");
			MyComboClear();
		}}
	
	public void PlayerLog(){}

	void Start () {
		ac = GetComponent<ActionList>();
		PlayerLog(); }

	void Update () { Inputs(); }
}
