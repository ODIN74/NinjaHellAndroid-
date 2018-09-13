using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BombSpawner : MonoBehaviour {

    public GameObject Bomb;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("hero");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (CrossPlatformInputManager.GetButtonDown("Fire2") && GameObject.FindGameObjectWithTag("Bomb") == null)
        {
            Instantiate(Bomb, new Vector3(transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
        }
	}
}
