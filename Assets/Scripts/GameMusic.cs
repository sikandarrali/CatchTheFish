using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {

	public AudioSource as_GameMusic;
    public GameObject gamovermusic_obj;
    public GameObject gamwinmusic_obj;

	void Start () {
		as_GameMusic = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
		if(Player_Movement_V2.flag_GameOver == true)
		{
            gamovermusic_obj.SetActive(true);
			as_GameMusic.Stop();
		}
        if(Player_Movement_V2.flag_GameWin == true)
		{
            gamwinmusic_obj.SetActive(true);
			as_GameMusic.Stop();
		}
		// if(Player_Movement.flag_GameOver == true || Player_Movement.flag_NextLevel == true)
		// {
		// 	as_GameMusic.Stop();
		// }
	}

}
