using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void SceneLoader()
	{
		SceneManager.LoadScene("Scene00");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
	void Start () {
	}

	void Update () {
		
	}
}
