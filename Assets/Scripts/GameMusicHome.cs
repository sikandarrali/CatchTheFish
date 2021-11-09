using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicHome : MonoBehaviour {

	public AudioSource gameMusicHome;

	private void Awake() {
		gameMusicHome = gameObject.GetComponent<AudioSource>();
	}

	void Start () {
		gameMusicHome.Play();
		gameMusicHome.loop = true;
	}
	
}
