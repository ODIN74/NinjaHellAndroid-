using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySpawner : MonoBehaviour
{
    public float spawnDistance = 5f;

    public GameObject enemy;

    private GameObject player;

    private bool spawnFlag = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("hero");
	}

    void Update()
    {
        Spawn(this.player);
    }

    void Spawn(GameObject obj)
    {
        if (!this.spawnFlag && ((transform.position.x - obj.transform.position.x) < this.spawnDistance))
        {
            Instantiate(this.enemy, transform.position, Quaternion.identity);
            this.spawnFlag = true;
            this.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
