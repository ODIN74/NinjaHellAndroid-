using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    private GameObject MainMenu;

    private GameObject AudioSettings;

    private void ShowMenu(GameObject menu)
    {
        MainMenu.SetActive(menu == MainMenu);
        AudioSettings.SetActive(menu == AudioSettings);
    }

    // Use this for initialization
    void Awake () {
        MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        AudioSettings = GameObject.FindGameObjectWithTag("AudioSettings");
        
        ShowMenu(MainMenu);
    }
	
    public void ShowMainMenu()
    {
        ShowMenu(MainMenu);
    }

    public void ShowAudioSettings()
    {

        ShowMenu(AudioSettings);
    }
}
