using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour {

    private GameObject pauseMenu;

    private GameObject winMenu;

    private GameObject lostMenu;

    private GameObject fakeObject;

    // Use this for initialization
    void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        winMenu = GameObject.Find("WinMenu");
        lostMenu = GameObject.Find("LostMenu");
        CloseMenu();
    }

    private void ShowMenu(GameObject menu)
    {
        pauseMenu.SetActive(menu == pauseMenu);
        winMenu.SetActive(menu == winMenu);
        lostMenu.SetActive(menu == lostMenu);
    }

    public void ShowPauseMenu()
    {
        Time.timeScale = 0f;
        ShowMenu(pauseMenu);
    }

    public void ShowWinMenu()
    {
        Time.timeScale = 0f;
        ShowMenu(winMenu);
    }

    public void ShowLostMenu()
    {
        Time.timeScale = 0f;
        ShowMenu(lostMenu);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        ShowMenu(fakeObject);
    }
}
