using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GUIStyle labelStyle;

    public GUIStyle buttonsStyle;

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 180, Screen.height / 2 - 100, 360, 200), "Main Menu", labelStyle);
        if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 30, 320, 40), "Start game", buttonsStyle))
        {
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 30, 320, 40), "Exit", buttonsStyle))
        {
            Application.Quit();
        }
    }


}
