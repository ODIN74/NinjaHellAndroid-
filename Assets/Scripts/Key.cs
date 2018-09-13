using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour {

    private LevelMenuController lmc;

    private void Awake()
    {
        lmc = FindObjectOfType<LevelMenuController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            lmc.ShowWinMenu();
        }
    }
}
