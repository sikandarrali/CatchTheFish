using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class FlockManager_V2 : MonoBehaviour {

	// public GameObject goalPrefab;

	public int main_numFish, main_numfishDummy;
	public GameObject fishPrefab, fishDummy_1, fishDummy_2, fishDummy_3;

	public static int tankSize = 30;
	public static int numFish, numfishDummy;

	public static GameObject[] allFish;
	public static GameObject[] allFish_1;
	public static GameObject[] allFish_2;
	public static GameObject[] allFish_3;

	public static GameObject[] gos_org;
	public static Vector3 goalPos = Vector3.zero;

	void Awake()
	{
		numFish = main_numFish;
		numfishDummy = main_numfishDummy;
		allFish = new GameObject[numFish];
		allFish_1 = new GameObject[numfishDummy];
		allFish_2 = new GameObject[numfishDummy];
	}
	// Use this for initialization
	void Start () {

		for(int i=0; i<numFish; i++){
			Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
										Random.Range(0,0),
		 							Random.Range(-tankSize,tankSize));
			allFish[i] = (GameObject) Instantiate(fishPrefab, pos,  Quaternion.Euler(new Vector3(0, Random.Range(0,180), 0)));
			allFish[i].gameObject.tag = "Fish_1";
		}

		for(int i=0; i<numfishDummy; i++){
			Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
										Random.Range(0,0),
		 							Random.Range(-tankSize,tankSize));
			allFish_1[i] = (GameObject) Instantiate(fishDummy_1, pos,  Quaternion.Euler(new Vector3(0, Random.Range(0,180), 0)));
			allFish_1[i].gameObject.tag = "Fish_2";
		}
 
		for(int i=0; i<numfishDummy; i++){
			Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
										Random.Range(0,0),
		 							Random.Range(-tankSize,tankSize));
			allFish_1[i] = (GameObject) Instantiate(fishDummy_2, pos,  Quaternion.Euler(new Vector3(0, Random.Range(0,180), 0)));
			allFish_1[i].gameObject.tag = "Fish_3";
		}

		for(int i=0; i<numfishDummy; i++){
			Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
										Random.Range(0,0),
		 							Random.Range(-tankSize,tankSize));
			allFish_2[i] = (GameObject) Instantiate(fishDummy_3, pos,  Quaternion.Euler(new Vector3(0, Random.Range(0,180), 0)));
			allFish_2[i].gameObject.tag = "Fish_4";
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Random.Range (0,100000) < 10){
			goalPos = new Vector3(Random.Range(-tankSize,tankSize),
									Random.Range(-0,0),
									Random.Range(-tankSize,tankSize));
		}
	}



}
