using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ThreeSecondsLoader : MonoBehaviour {

    public AudioSource sound_GameBegins;
    public static bool flag_3SecOvers = false;
	public GameObject p_CountDown;

	// [HideInInspector]
	public int timeLeft = 5; //Seconds Overall
	public TextMeshProUGUI countdown; //UI Text Object

	private void Start() {
		StartCoroutine("LoseTime");
		Time.timeScale = 1; //Just making sure that the timeScale is right
	}


	void OnEnable() {
		sound_GameBegins = gameObject.GetComponent<AudioSource>();
        sound_GameBegins.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(timeLeft<0)
			timeLeft = 0;

		countdown.text = ("" + timeLeft); //Showing the Score on the Canvas

		if(timeLeft <= 0)
		{
            p_CountDown.SetActive(false);
            flag_3SecOvers = true;
		}


	}

	//Simple Coroutine
	IEnumerator LoseTime()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			timeLeft--; 
		}
	}


}
