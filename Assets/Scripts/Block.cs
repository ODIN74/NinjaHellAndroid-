using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private GameObject player;

    public float backForcePlayer = 2000f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            var playerDirection = Mathf.Sign(player.transform.position.x - transform.position.x);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerDirection * Vector2.one.x, 0f) * backForcePlayer);
            player.GetComponent<MyPlayerControl>().Demage();
        }
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
}
