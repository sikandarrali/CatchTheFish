using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMusic : MonoBehaviour {

	public AudioSource as_GameMusic;
	void Start () {
		as_GameMusic = gameObject.GetComponent<AudioSource>();
		if(gameObject.activeSelf)
		{
			as_GameMusic.Play();
		}
	}

}
