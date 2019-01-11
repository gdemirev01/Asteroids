using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }

    public void ChooseControls(bool type)
    {
        PlayerController.controlsType = !PlayerController.controlsType;
    }

    public void SetVolume(GameObject slider)
    {
        GameInfo.volume = slider.GetComponent<Slider>().value;
        Debug.Log(GameInfo.volume);
    }

    public void Back()
    {
        ToggleMenu("SettingsMenu", false);
        ToggleMenu("ShopMenu", false);
        ToggleMenu("MainMenu", true);
    }

    public void Shop()
    {
        ToggleMenu("ShopMenu", true);
        ToggleMenu("MainMenu", false);
    }

    public void Settings()
    {
        ToggleMenu("SettingsMenu", true);
        ToggleMenu("MainMenu", false);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    private void ToggleMenu(string name, bool enabled)
    {
        if (GameObject.Find(name))
        {
            CanvasGroup canvas = GameObject.Find(name).GetComponent<CanvasGroup>();
            if (enabled)
            {
                canvas.alpha = 1;
                canvas.interactable = true;
                canvas.blocksRaycasts = true;
            }
            else
            {
                canvas.alpha = 0;
                canvas.interactable = false;
                canvas.blocksRaycasts = false;
            }
        }
    }
}
