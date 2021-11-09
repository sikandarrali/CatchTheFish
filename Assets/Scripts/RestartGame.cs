using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {

    private Scene m_Scene;
    private string sceneName;

    public void restartGame()
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


}