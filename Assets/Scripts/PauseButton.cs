using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

    private LevelMenuController lmc;

    private Button btnPause;

    private void Awake()
    {
        lmc = FindObjectOfType<LevelMenuController>();
        btnPause = GetComponent<Button>();
        btnPause.onClick.AddListener(() => OpenPauseMenu());
    }

    private void OpenPauseMenu()
    {
        lmc.ShowPauseMenu();
    }
}
