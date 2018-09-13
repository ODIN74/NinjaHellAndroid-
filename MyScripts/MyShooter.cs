using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MyShooter : MonoBehaviour {

    public GameObject weapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Instantiate(weapon, new Vector3(transform.position.x,transform.position.y), Quaternion.identity);
        }
    }
}
