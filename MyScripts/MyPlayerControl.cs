using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MyPlayerControl : MonoBehaviour
{

    public float speed = 2f;

    public int Helth = 100;

    public float jumpForce = 1000f;

    public AudioClip hit;

    private float maxSpeed = 10f;

    private float minSpeed = 1f;

    private bool jumpFlag = false;

    private bool inFly = false;

    private int groundIndex = 0;

    private Rigidbody2D playerRigidbody;

    private Vector2 direction;

    private Animator anim;

    private LevelMenuController lmc;

    private AudioSource AudioSource;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == this.groundIndex)
        {
            jumpFlag = true;
        }
    }

    // Use this for initialization
    void Start ()
	{
	    this.groundIndex = LayerMask.NameToLayer("Ground");
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lmc = FindObjectOfType<LevelMenuController>();
        AudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Helth <= 0)
        {
            Destroy(gameObject);
            lmc.ShowLostMenu();
        }
        if (jumpFlag && CrossPlatformInputManager.GetAxis("Vertical") == 1)
	    {
	        jumpFlag = false;
            inFly = true;
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Idle");
            anim.SetTrigger("Jump"); 
            anim.SetTrigger("Idle"); 
        }  
    }

    private void FixedUpdate()
    {//
        direction.x = CrossPlatformInputManager.GetAxis("Horizontal");

        if (direction.x > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        if (direction.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180f, Vector3.up);
        }

        if (direction.magnitude > 0.05f)
        {
            playerRigidbody.velocity = new Vector2(direction.normalized.x * Mathf.Clamp(speed, minSpeed, maxSpeed), playerRigidbody.velocity.y);
            anim.ResetTrigger("Idle");
            anim.SetTrigger("Walk");
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Idle");
        }

        if (inFly)
        {
            playerRigidbody.AddForce(new Vector2( 0f, jumpForce));
            inFly = false;
        }
    }

    public void Demage()
    {
        Helth -= 10;
        AudioSource.clip = hit;
        AudioSource.Play();
        Handheld.Vibrate();
    }
}
