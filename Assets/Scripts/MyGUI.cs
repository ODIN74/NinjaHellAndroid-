using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGUI : MonoBehaviour {

    private MyPlayerControl playerControl;

    private bool startPlay = false;

    delegate bool StartGame(bool startButton);

    private void Start()
    {

        playerControl = GameObject.Find("hero").GetComponent<MyPlayerControl>();

    }

    private void OnGUI()
    {
            var text = "Здровье: " + playerControl.Helth;
            GUI.Label(new Rect(10, 10, 100, 20), text);
    }
}
