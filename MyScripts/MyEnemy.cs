using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    public float enemySpeed;

    public int hitToDeath = 1;

    public float backForcePlayer = 600f;

    public AudioClip startSound;

    public AudioClip hitSound;

    private GameObject player;

    private Animator anim;

    private bool attackFlag = false;

    private AudioSource myAudioSorce;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Weapon") || collider.gameObject.tag.Equals("Bomb"))
        {
            this.hitToDeath--;
            if (!myAudioSorce.isPlaying)
            {
                myAudioSorce.clip = hitSound;
                myAudioSorce.Play();
            }
            if (this.hitToDeath == 0)
            {
                    anim.SetTrigger("Die");
                    attackFlag = false;
                    Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            }
            
        }
    }

    private void Awake()
    {
            anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		this.player = GameObject.Find("hero");
        myAudioSorce = GetComponent<AudioSource>();
        myAudioSorce.clip = startSound;
        myAudioSorce.Play();
        anim.ResetTrigger("Appear");
    }
	
	// Update is called once per frame
	void Update ()
	{
            if (Vector2.Distance(transform.position, player.transform.position) <= 2f)
            {
                anim.ResetTrigger("Walk");
                anim.SetTrigger("Attack");
                if (!attackFlag)
                {
                    attackFlag = true;
                    StartCoroutine("Attack");
                }
                
            }
            else
            {
                attackFlag = false;
                anim.SetTrigger("Walk");

                if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton1_die") ^
                    anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton1_app")) &&
                    transform.position.x >= this.player.transform.position.x)
                {
                    transform.rotation = Quaternion.identity;
                    transform.Translate(Vector2.left * this.enemySpeed * Time.deltaTime, Space.World);
                }
                else if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton1_die") ^
                         anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton1_app")))
                {
                    transform.rotation = Quaternion.Euler(0, 180f, 0);
                    transform.Translate(Vector2.right * this.enemySpeed * Time.deltaTime, Space.World);
                }
            }
    }

    IEnumerator Attack()
    {
        while(attackFlag)
        {
            yield return new WaitForSeconds(0.5f);
            var playerDirection = Mathf.Sign(player.transform.position.x - transform.position.x);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerDirection * Vector2.one.x, 0f) * backForcePlayer);
            player.GetComponent<MyPlayerControl>().Demage();
        }      
    }
}
