using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton2Weapon : MonoBehaviour {

    public float WeaponSpeed;

    public float backForcePlayer = 600f;

    private GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            var playerDirection = Mathf.Sign(player.transform.position.x - transform.position.x);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerDirection * Vector2.one.x, 0f) * backForcePlayer);
            player.GetComponent<MyPlayerControl>().Demage();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "Enemy") Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        player = GameObject.Find("hero");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * WeaponSpeed * Time.deltaTime, Space.Self);
    }
}
