using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour {

    private LevelMenuController lmc;

    private void Awake()
    {
        lmc = FindObjectOfType<LevelMenuController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Player")) lmc.ShowLostMenu();

    }

}
