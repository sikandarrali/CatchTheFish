using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash_home_manager : MonoBehaviour {


	public AudioSource a_src;
	public AudioClip a_clp;


	private float delay = 3f;
	public GameObject splashScreen, homeScreen;

	void Awake()
	{
		a_src = gameObject.GetComponent<AudioSource>();
	}

	void Start()
	{
		a_src.Play();
		StartCoroutine(LoadLevelAfterDelay(delay));
	}

	IEnumerator LoadLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		splashScreen.SetActive(false);
		a_src.PlayOneShot(a_clp,1);
		homeScreen.SetActive(true);
	}




	
}
