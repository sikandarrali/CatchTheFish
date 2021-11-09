using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	//GameOver
	public GameObject p_GameOver;
	public TextMeshProUGUI t_GameResult;

	public GameObject restartGame;

	public GameObject p_GameWin;
	public TextMeshProUGUI t_GameWinResult;

	public GameObject RestartObject;

	void Update()
	{

		if(Player_Movement_V2.flag_GameOver == true)
			GameOver();

		if(Player_Movement_V2.flag_GameWin == true)
			GameWin();

	}

	void GameOver()
	{
		Time.timeScale = 0;
		p_GameOver.SetActive(true);
		t_GameResult.text = "Fish Caught = " + Player_Movement_V2.Score + "/8";
		RestartObject.SetActive(true);

		// restartGame.SetActive(true);
	}
	void GameWin()
	{
		Time.timeScale = 0;
		p_GameWin.SetActive(true);
		t_GameWinResult.text = "Fish Caught = " + Player_Movement_V2.Score + "/8";
		RestartObject.SetActive(true);
		// restartGame.SetActive(true);
	}
	
}
