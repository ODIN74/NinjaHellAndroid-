using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour {

    private Button btnSettings;

    private MainMenuController mmc;

    private void Awake()
    {
        mmc = FindObjectOfType<MainMenuController>();
    }
    // Use this for initialization
    void Start () {
        btnSettings = GetComponent<Button>();
        btnSettings.onClick.AddListener(() => OpenSettingsWindow());
	}
	
	// Update is called once per frame
	void OpenSettingsWindow()
    {
        mmc.ShowAudioSettings();
    }
}
