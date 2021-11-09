using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerInput : MonoBehaviour {

    public Animator anim;
    public GameObject animatorOBJ;

    public SteamVR_Action_Boolean pich;
 
    public SteamVR_TrackedObject trb;
    public float player_speed = 100;
    private Camera cam;
    public Vector3 controller_pos;
    public float smoothTime = 10F;
    private Vector3 velocity = Vector3.zero;


    private Scene m_Scene;
    private string sceneName;
    public GameObject restartGame_obj;
    public int sceneIndex;

    public GameObject loadingScreen;
    public Slider slider;
    public Text loadingPercentage;



    void Start()
    {
        transform.position = trb.transform.position;
        anim  = animatorOBJ.GetComponent<Animator>();
        cam = Camera.main;


       
        sceneName = m_Scene.name;
    }



    private void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);

        if (sceneName == "Home")
        {
            if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.Any))
            {
                StartCoroutine(playGamewithController());
                Debug.Log("Pressed");
            }
        }

        if (sceneName == "GamePlay")
        {
            if (restartGame_obj.activeSelf)
            {
                if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.Any))
                {
                    restartGamewithController();
                }
            }
        }

        //if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
        //{
        //  triggerPressed = true;
        //}
        controller_pos = (trb.transform.position) * 15;
        controller_pos.y = 0;
        controller_pos = -controller_pos;

        transform.eulerAngles = new Vector3(0, trb.transform.eulerAngles.y + 180, 0);
        transform.position = controller_pos;
    }


    public void restartGamewithController()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        Player_Movement_V2.Score = 0;
        Player_Movement_V2.caughtCheck = 0;
        Player_Movement_V2.Tries = 5;
        Player_Movement_V2.flag_GameOver = false;
        Player_Movement_V2.flag_GameWin = false;

        FlockManager_V2.tankSize = 30;
        FlockManager_V2.goalPos = Vector3.zero;

        SceneManager.LoadScene(sceneName);
    }


    IEnumerator playGamewithController()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GamePlay");

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            loadingPercentage.text = progress * 100f + "%";
            yield return null;
        }
    }


}
