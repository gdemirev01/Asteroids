using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }

    public void ChooseControls()
    {

        PlayerController.controlsType = !PlayerController.controlsType;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
