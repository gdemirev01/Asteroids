using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public int winScore = 100;
    public static int score;

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
            if (Time.timeScale == 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Pause";
                transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            score = 0;
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
