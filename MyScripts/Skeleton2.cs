using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton2 : MonoBehaviour {

    public float FarDistance = 10f;

    public float NearDistance = 3f;

    public float backForcePlayer = 600f;

    public int hitToDeath;

    public AudioClip hitSound;

    public AudioClip startSound;

    private GameObject player;

    private RaycastHit2D farHit;

    private RaycastHit2D nearHit;

    public bool farAttack = false;

    private bool nearAtack = false;

    private Animator anim;

    private AudioSource myAudioSorce;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Weapon"))
        {
            this.hitToDeath--;
            if(!myAudioSorce.isPlaying)
            {
                myAudioSorce.clip = hitSound;
                myAudioSorce.Play();
            }
            if (this.hitToDeath == 0)
            {
                farAttack = false;
                nearAtack = false;
                StopCoroutine(NearAttack());
                anim.SetTrigger("Die");
                Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            }

        }
    }

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("hero");
        anim = GetComponent<Animator>();
        myAudioSorce = GetComponent<AudioSource>();
        myAudioSorce.clip = startSound;
        myAudioSorce.Play();
    }

    private void Update()
    {
        if (transform.position.x < player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    void FixedUpdate ()
    {
        if (transform.position.x < player.transform.position.x)
        {
            farHit = Physics2D.Raycast(transform.position, Vector2.right, FarDistance, 1 << player.layer);
            nearHit = Physics2D.Raycast(transform.position, Vector2.right, NearDistance, 1 << player.layer);
        }
        else
        {
            farHit = Physics2D.Raycast(transform.position, Vector2.left, FarDistance, 1 << player.layer);
            nearHit = Physics2D.Raycast(transform.position, Vector2.left, NearDistance, 1 << player.layer);
        }     

        Debug.DrawRay(transform.position, Vector2.left * FarDistance, Color.green);
        Debug.DrawRay(transform.position, Vector2.left * NearDistance, Color.cyan);

        if (nearHit.collider != null)
        {
            farAttack = false;
            anim.ResetTrigger("Attack1");
            anim.SetTrigger("Attack2");
            Debug.DrawRay(transform.position, Vector2.left * NearDistance, Color.blue);
            if (!nearAtack)
            {
                nearAtack = true;
                StartCoroutine(NearAttack());
            }
        }
        else if (farHit.collider != null)
        {
            farAttack = true;
            StopCoroutine(NearAttack());
            nearAtack = false;
            anim.ResetTrigger("Idle");
            anim.SetTrigger("Attack1");
            Debug.DrawRay(transform.position, Vector2.left * FarDistance, Color.red);
        }
        else
        {
            farAttack = false;
            StopCoroutine(NearAttack());
            nearAtack = false;
            anim.ResetTrigger("Attack1");
            anim.ResetTrigger("Attack2");
            anim.SetTrigger("Idle");
        }
	    	
	}

    IEnumerator NearAttack()
    {
        while(nearAtack)
        {
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
            var playerDirection = Mathf.Sign(player.transform.position.x - transform.position.x);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerDirection * Vector2.one.x, 0f) * backForcePlayer);
            player.GetComponent<MyPlayerControl>().Demage();
        }
    }
}
