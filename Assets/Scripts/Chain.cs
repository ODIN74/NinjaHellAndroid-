using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour {

    public GameObject player;

    public GameObject chain;

    public float destroyTime = 10f;

    public float distanceToPlayer = 8f;

    private bool objectCreated = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(!objectCreated &&  Vector2.Distance(new Vector2(transform.position.x, 0f), new Vector2 (player.transform.position.x, 0f)) < distanceToPlayer)
        {
            objectCreated = true;
            Instantiate(chain, transform);
            Destroy(gameObject, destroyTime);
        }

	}
}
