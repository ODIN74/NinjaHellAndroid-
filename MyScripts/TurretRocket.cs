using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRocket : MonoBehaviour {


    public float RocketSpeed = 10f;

    private GameObject player;

    private MyPlayerControl playerControl;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerControl.Demage();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "Enemy") Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        player = GameObject.Find("hero");
        playerControl = player.GetComponent<MyPlayerControl>();
        GetComponentInChildren<ParticleSystem>().Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * RocketSpeed * Time.deltaTime, Space.World);
	}
}
