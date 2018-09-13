using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour {

    private LevelMenuController lmc;

    private Button btnResume;

    private void Awake()
    {
        lmc = FindObjectOfType<LevelMenuController>();
        btnResume = GetComponent<Button>();
        btnResume.onClick.AddListener(() => ClosePauseMenu());
    }

    private void ClosePauseMenu()
    {
        lmc.CloseMenu();
    }
}
