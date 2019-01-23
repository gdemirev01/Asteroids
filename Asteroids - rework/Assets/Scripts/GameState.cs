using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public int winScore = 100;
    public static int score;
    public bool isPaused = false;

    // Update is called once per frame
    void Update () {
        CheckState();
	}

    public void CheckState()
    {
        //if (score >= winScore)
        //{
        //    ResultsOfGame.result = "You Win";
        //    ResultsOfGame.score = score;
        //    score = 0;
        //    SceneManager.LoadScene("ResultOfPlay", LoadSceneMode.Single);
        //}
        if (GameObject.Find("TUES_PlayerShip").GetComponent<GameObjectDetails>().health <= 0)
        {
            ResultsOfGame.result = "You Lose";
            ResultsOfGame.score = score;
            score = 0;
            SceneManager.LoadScene("ResultOfPlay", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                GetComponent<MenuController>().PauseGame(false);
                Time.timeScale = 1;
                GameObject.Find("TUES_PlayerShip").GetComponent<PlayerController>().enabled = true;
                isPaused = false;
            }
            else
            {
                GetComponent<MenuController>().PauseGame(true);
                Time.timeScale = 0;
                GameObject.Find("TUES_PlayerShip").GetComponent<PlayerController>().enabled = false;
                isPaused = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            score = 0;
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
