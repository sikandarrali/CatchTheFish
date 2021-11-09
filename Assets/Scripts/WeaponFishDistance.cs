using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFishDistance : MonoBehaviour {

	public Transform distance_water;
	public Transform distance_fish;

	void Start () {
		distance_water = GameObject.Find("WaterWrapper").transform;
		distance_fish = GameObject.FindGameObjectWithTag("Fish").transform;
	}

	void LateUpdate()
	{
		Scoop_Active_Deactive();
	}
 
    void Scoop_Active_Deactive()
    {
        // if (distance_water)
        // {
        //     float dist = Vector3.Distance(distance_water.position, transform.position);
        //     // print("Distance to Water: " + dist);
		// 	if(dist <= 17.5f){
		// 		print("Active");
		// 	}else{
		// 		print("Inactive");
		// 	}
        // }
    }
	
}
