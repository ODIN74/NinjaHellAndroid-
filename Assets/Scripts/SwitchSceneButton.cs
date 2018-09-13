using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchSceneButton : MonoBehaviour {

    public string SceneName;

    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => SceneLoad());
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1f;
    }

}
