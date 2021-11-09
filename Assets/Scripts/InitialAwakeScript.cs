using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialAwakeScript : MonoBehaviour {
	
	public GameObject threesecloader;
	public GameObject FlockM;

	// Use this for initialization
	void Update () {

		if(threesecloader.activeSelf == false)
			FlockM.SetActive(true);

	}
}
 