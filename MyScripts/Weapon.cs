using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float weaponForce = 10f;

    public int groundLayerNumber;

    public int enemyLayerNumber;

    public AudioClip hit;

    public AudioClip swing;

    private GameObject player;

    private Rigidbody2D playerRigidbody;

    private Quaternion playerRotationAtStartShot;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == groundLayerNumber || collider.gameObject.layer == enemyLayerNumber || collider.gameObject.tag.Equals("wall"))
        {
            AudioSource.PlayClipAtPoint(this.hit, transform.position);
            Destroy(gameObject);
        }  
    }

    // Use this for initialization
    void Start ()
    {
        AudioSource.PlayClipAtPoint(this.swing, transform.position);

        this.player = GameObject.Find("hero");
        this.playerRotationAtStartShot = this.player.transform.rotation;

        if (this.playerRotationAtStartShot.y == 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(weaponForce, 0f));
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-weaponForce, 0f));
        }
        Destroy(gameObject, 2);
	}
	
}
