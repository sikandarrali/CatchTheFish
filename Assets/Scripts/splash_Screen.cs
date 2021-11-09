using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash_Screen : MonoBehaviour {

	private float delay = 3f;
	public GameObject splashScreen, homeScreen;


	void Start()
	{
		StartCoroutine(LoadLevelAfterDelay(delay));
	}

	IEnumerator LoadLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		splashScreen.SetActive(false);
		homeScreen.SetActive(true);
	}
}
