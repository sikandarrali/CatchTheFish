using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	public static bool flag_OneMinute = false;
	[HideInInspector]
	public TextMeshProUGUI gameTimerText;
	public float gameTimer = 0f;
	public static float gameTime = 126f;
	public static float startTime;
	public static float elapsedTime;

	void Start () {

		elapsedTime = 0;
		gameTime = 126f;

		startTime = Time.time;
	}

	void Awake()
	{
		gameTimerText = GetComponent<TextMeshProUGUI>();
	}

	void Update()
	{
		elapsedTime = Time.time - startTime;
		int minutes = (int)((gameTime - elapsedTime) / 60) % 60;
		int seconds = (int)((gameTime - elapsedTime) % 60);
		string gameTimerString = string.Format("{0:00}:{1:00}", minutes, seconds);
		gameTimerText.text = gameTimerString;
		
		if(elapsedTime == gameTime/2)
			flag_OneMinute = true;
		
		if (elapsedTime >= gameTime)
		{
			gameTimerText.text = "00:00";
		}	
	}
}
