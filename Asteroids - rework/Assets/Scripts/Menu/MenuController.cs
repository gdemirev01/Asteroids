using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    bool loaded = false;

    private void Awake()
    {
        SaveSystem.LoadPlayer();
    }

    private void Update()
    {
        GameObject.Find("Record").GetComponent<Text>().text = GameInfo.record.ToString();
    }

    public void StartGame()
    {
        SaveSystem.LoadPlayer();
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void BackToMenu()
    {
        SaveSystem.LoadPlayer();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void ChooseControls(bool type)
    {
        PlayerController.controlsType = type;
        SaveSystem.SavePlayer();
    }

    public void SetVolume(GameObject slider)
    {
        GameInfo.volume = slider.GetComponent<Slider>().value;
        SaveSystem.SavePlayer();
    }

    public void Back()
    {
        SaveSystem.SavePlayer();
        ToggleMenu("SettingsMenu", false);
        ToggleMenu("ShopMenu", false);
        ToggleMenu("MainMenu", true);
    }

    public void Shop()
    {
        SaveSystem.SavePlayer();
        ToggleMenu("ShopMenu", true);
        ToggleMenu("MainMenu", false);
    }

    public void Settings()
    {
        SaveSystem.SavePlayer();
        ToggleMenu("SettingsMenu", true);
        ToggleMenu("MainMenu", false);
    }

    public void EndGame()
    {
        SaveSystem.SavePlayer();
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
