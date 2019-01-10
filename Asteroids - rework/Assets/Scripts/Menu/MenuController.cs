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

    public void Back()
    {
        GameObject.Find("SettingsMenu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Main").GetComponent<Canvas>().enabled = true;
    }

    public void Settings()
    {
        GameObject.Find("SettingsMenu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("Main").GetComponent<Canvas>().enabled = false;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
