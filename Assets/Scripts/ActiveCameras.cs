using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCameras : MonoBehaviour {





	// Use this for initialization
	void Start () {

		Display.displays[0].Activate();
		Display.displays[1].Activate();
		Display.displays[2].Activate();
		Display.displays[3].Activate();
		Display.displays[4].Activate();
		Display.displays[5].Activate();
		Display.displays[6].Activate();
		Display.displays[7].Activate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
