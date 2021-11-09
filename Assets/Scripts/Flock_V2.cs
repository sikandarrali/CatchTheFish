using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock_V2 : MonoBehaviour
{

    public float fishSpeed;
    float roationSpeed = 3.0f;
    float neighbourDistance = 1f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    private GameObject weapon;
        
    // Camera camera;
    bool turning = false;

    public GameObject[] gos;

    public float fish_score = 0;


    public Transform distance_weapon;

    public Vector3 PrevPosition;
    public float weapon_Velocity;

    
    void Start()
    {
        fishSpeed = Random.Range(4f, 8f);
        // camera=Camera.main;
        weapon = GameObject.FindWithTag("weapon");

        // int allFish = FlockManager_V2.number_of_fish;
        // int remainingFish = FlockManager_V2.fishwithtag();
        // int finalScore = allFish - remainingFish;
        
        // gos = FlockManager_V2.gos_org; 

        //  foreach(GameObject h in gos)
        // {
        //     Debug.Log(h);
        // }
        distance_weapon = GameObject.Find("WeaponController").transform;

    }

    void Update()
    {

        if (Vector3.Distance(transform.position, Vector3.zero) >= FlockManager_V2.tankSize)
        {
            turning = true;
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    roationSpeed * Time.deltaTime);
            fishSpeed = Random.Range(2.5f, 5f);
            transform.Translate(0, 0, Time.deltaTime * fishSpeed);
        }
        else
        {
            turning = false;
            if (Random.Range(1f, 2f) < 3)
            {
                applyRules();
            }
            transform.Translate(0, 0, Time.deltaTime * fishSpeed);
        }

        if(turning){
        	Vector3 direction = Vector3.zero - transform.position;
        	transform.rotation = Quaternion.Slerp(transform.rotation,
        											Quaternion.LookRotation(direction),
        											roationSpeed * Time.deltaTime);
        	fishSpeed = Random.Range(2.5f, 5f);

        	// StartCoroutine (changeValues());

        // }else{
        // 	if(Random.Range(2.5f, 5f) < 1){
        // 		applyRules();
        // 	}
        	transform.Translate(0,0,Time.deltaTime * fishSpeed);

        	// StartCoroutine (changeValues());
        }
        

        
        find_WeaponVeolcity();
        dist_FishWeapon();
        increaseSpeedwithTime();

        if(TimerScript.flag_OneMinute == true)
            Debug.Log("Half Time"); 
    }

    void applyRules()
    {

        GameObject[] gos_0 = FlockManager_V2.allFish;
        GameObject[] gos_1 = FlockManager_V2.allFish_1;
        // GameObject[] gos_2 = FlockManager_V2.allFish_2;
        // GameObject[] gos_3 = FlockManager_V2.allFish_3;
        
        // GameObject[] gos = FlockManager_V2.allFish;

        GameObject[] gos = new GameObject [gos_0.Length + gos_1.Length];
        
        gos_0.CopyTo(gos,0);
        gos_1.CopyTo(gos,gos_0.Length);
        // gos_2.CopyTo(gos,gos_0.Length + gos_1.Length);
        // gos_3.CopyTo(gos,gos_0.Length + gos_1.Length + gos_2.Length);

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.5f;

        Vector3 goalPos = FlockManager_V2.goalPos;

        float dist;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;
                    if (dist < 2f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }
                    Flock_V2 anotherFlock = go.GetComponent<Flock_V2>();
                    gSpeed = gSpeed + anotherFlock.fishSpeed;
                }
            }
        }

        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalPos - this.transform.position);
            fishSpeed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        roationSpeed * Time.deltaTime);
            }
        }

    }


    void find_WeaponVeolcity()
    {
        //Find Weapon Velocity
        weapon_Velocity = ((weapon.transform.position - PrevPosition).magnitude) / Time.deltaTime;
        PrevPosition = weapon.transform.position;
        // print("Weapon Velocity: " + weapon_Velocity);
    }
    void dist_FishWeapon()
    {
		if (distance_weapon)
        {
            float dist = Vector3.Distance(distance_weapon.position, transform.position);
            // print("Distance to Weapon: " + dist);

            if(dist<20f){
                if(weapon_Velocity > 12 ){
                    fishSpeed = 15f;
                    
                    // Rotate Fish when Player comes near
                    float smooth = 2.0f;
                    float tiltAngle = 60.0f;
                    Quaternion target = Quaternion.Euler(0, tiltAngle, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
                }
            }
        }
	}


    void increaseSpeedwithTime()
    {
        if(TimerScript.elapsedTime >= 86 )
		{
			fishSpeed = 8f;
		}
        if(TimerScript.elapsedTime >= 111 )
		{
			fishSpeed = 10f;
		}
    }


    // void OnCollisionEnter(Collision col)
    // {

    //     // if (weapon)
    //     // {
    //     //     gameObject.SetActive(false);
    //     //     ScoreScript.scoreValue += 10;
    //     // }


    //     // foreach (ContactPoint contact in col.contacts)
    //     // {
    //     //     print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
    //     //     // Debug.Log( "Contact Point: " + contact.point + " Contact Normal: " + contact.normal);


    //     // 	// GameObject.CreatePrimitive(PrimitiveType.Cube);
    //     // 	// GameObject newcube  = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //     // 	// newcube.transform.position = contact.point;

    //     // 	// GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //     // 	// cube.transform.position = new Vector3(0, 0.5f, 0);

	// 	// 	// particles.Play();

    //     // }


    // }

}
