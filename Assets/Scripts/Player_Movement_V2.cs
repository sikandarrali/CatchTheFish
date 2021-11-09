using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Movement_V2 : MonoBehaviour {

	private int playerSpeed = 10; // only when using keyboard for movement, NOT needed when playing with VIVE Controller
	
	public AudioSource audioSource;
	public AudioClip necksnap; // played when target fish is caught
	public AudioClip buzzer; // played when wrong fish is caught

	[HideInInspector]
	public static int Score = 0; // Not displayed, but logic is based on it
	public static int caughtCheck = 0; // Not displayed, but logic is based on it
	
	[HideInInspector]
	public static int Tries = 5; // Fish Catch Tries (if you increase this make sure you increase number of Fish also)
	public GameObject go_Tries; // Tries Game Object - Added from Inspector
	[HideInInspector]
	public TextMeshProUGUI text_Tries; // Empty TMPro Obj
	
	public static bool flag_GameOver = false,  flag_GameWin = false;

	public Sprite caughtTick; // Tick Sprite to add on fish when caught, added from Inspector


 	void OnEnable () {
		audioSource = GetComponent<AudioSource>();
		text_Tries = go_Tries.GetComponent<TextMeshProUGUI>();
		
		
		TimerScript.elapsedTime = 0;
		
		Score = 0;
		caughtCheck = 0;
		Tries = 5;
		flag_GameOver = false;
		flag_GameWin = false;
		

	}


	private void Update() {
		
	}


	void LateUpdate () {

		KeyboardMove(); // for Testing Only, when Vive Controllers are not available, can be removed
		markCaughtFish(); // marks each fish with TICK when its caught
		checkGamePlayTime(); // returns "flagGameOver" when Time is Up or Tries are finished

		text_Tries.text = Tries.ToString(); // Updates Tries Left to Game Display
		
    }

	public void KeyboardMove()
	{
		Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		this.transform.position += Movement * playerSpeed * Time.deltaTime;
	}

	public void markCaughtFish()
	{
		for(int i=1; i<=Score; i++)
		{
			GameObject.Find("cf_" + i).GetComponent<Image>().sprite = caughtTick;
		}
		if(Score == 8)
		{
			flag_GameWin = true;
		}
	}

	public void checkGamePlayTime()
	{
		if(TimerScript.elapsedTime >= TimerScript.gameTime || Tries == 0)
		{
			flag_GameOver = true;
		}
	}

	void OnCollisionEnter (Collision Scoop_Col)
    {
		Debug.Log("Score: " + Score);
		Debug.Log("Tries: " + Tries);
		Debug.Log("Check Int: " + caughtCheck);


		if( caughtCheck == 0)
		{
			if (Scoop_Col.gameObject.tag == "Fish_1")
			{
				audioSource.PlayOneShot(necksnap, 1);
				Scoop_Col.gameObject.SetActive(false);
				Score += 1;
				if(Score >= 2 && Score <= 3 )
				{
					Score = 2;
					caughtCheck = 1;
					return;
				}
			} 
			else
			{
				if(Scoop_Col.gameObject.tag == "Fish_2" || Scoop_Col.gameObject.tag == "Fish_3" || Scoop_Col.gameObject.tag == "Fish_4")
				{					
					audioSource.PlayOneShot(buzzer, 1);
					Scoop_Col.gameObject.SetActive(false);
					// Score = Score - 1;					
					Tries = Tries - 1;
				}
			}
		}

		if( caughtCheck == 1)
		{
			if (Scoop_Col.gameObject.tag == "Fish_2")
			{				
				audioSource.PlayOneShot(necksnap, 1);
				Scoop_Col.gameObject.SetActive(false);
				Score += 1;
				if(Score >= 4 && Score <= 5 )
				{
					Score = 4;
					caughtCheck = 2;
					return;
				}
			}
			else
			{
				if(Scoop_Col.gameObject.tag == "Fish_1" || Scoop_Col.gameObject.tag == "Fish_3" || Scoop_Col.gameObject.tag == "Fish_4")
				{					
					audioSource.PlayOneShot(buzzer, 1);
					Scoop_Col.gameObject.SetActive(false);
					// Score = Score - 1;					
					Tries = Tries - 1;
				}
			}
			
		}

		if( caughtCheck == 2)
		{
			if (Scoop_Col.gameObject.tag == "Fish_3")
			{
				audioSource.PlayOneShot(necksnap, 1);
				Scoop_Col.gameObject.SetActive(false);
				Score += 1;
				if(Score >= 6 && Score <= 7 )
				{
					Score = 6;
					caughtCheck = 3;
					return;
				}
			}
			else
			{
				if(Scoop_Col.gameObject.tag == "Fish_1" || Scoop_Col.gameObject.tag == "Fish_2" || Scoop_Col.gameObject.tag == "Fish_4")
				{				
					audioSource.PlayOneShot(buzzer, 1);
					Scoop_Col.gameObject.SetActive(false);
					// Score = Score - 1;					
					Tries = Tries - 1;
				}
			}
			
		}

		if( caughtCheck == 3)
		{
			if (Scoop_Col.gameObject.tag == "Fish_4")
			{				
				audioSource.PlayOneShot(necksnap, 1);
				Scoop_Col.gameObject.SetActive(false);
				Score += 1;
				if(Score > 8 )
				{
					caughtCheck = 4;
					return;
				}
			}
			else
			{
				if(Scoop_Col.gameObject.tag == "Fish_1" || Scoop_Col.gameObject.tag == "Fish_2" || Scoop_Col.gameObject.tag == "Fish_3")
				{					
					audioSource.PlayOneShot(buzzer, 1);
					Scoop_Col.gameObject.SetActive(false);
					// Score = Score - 1;					
					Tries = Tries - 1;
				}
			}
			
		}

		if( caughtCheck == 4)
		{

			if(Scoop_Col.gameObject.tag == "Fish_1" || Scoop_Col.gameObject.tag == "Fish_2" || Scoop_Col.gameObject.tag == "Fish_3" || Scoop_Col.gameObject.tag == "Fish_4")
			{
				audioSource.PlayOneShot(necksnap, 1);
				Scoop_Col.gameObject.SetActive(false);
				// Score = Score - 1;					
				Tries = Tries - 1;
			}
			
		}

	}

}



