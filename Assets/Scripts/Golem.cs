using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour {

    public float enemySpeed;

    public int hitToDeath = 4;

    public float backForcePlayer = 600f;

    public float distance;

    public AudioClip startSound;

    public AudioClip hitSound;

    private GameObject player;

    private Animator anim;

    private RaycastHit2D playerVisible;

    private Vector3 startPosition;

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
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Attack");
                anim.SetTrigger("Die");
                StopCoroutine(Attack());
                Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            }

        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        this.player = GameObject.Find("hero");
        startPosition = transform.position;
        myAudioSorce = GetComponent<AudioSource>();
        myAudioSorce.clip = startSound;
        myAudioSorce.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= 3f)
        {
                anim.ResetTrigger("Idle");
                anim.SetTrigger("Attack");
            if (!attackFlag)
            {
                attackFlag = true;
                StartCoroutine(Attack());
            }
                
        }
        else
        {
            attackFlag = false;
            StopCoroutine(Attack());
        }

        if (playerVisible.collider != null)
        {
            anim.SetTrigger("Idle");

            if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("Golem_Die") ^                   
                anim.GetCurrentAnimatorStateInfo(0).IsName("Golem_app")) &&                    
                transform.position.x >= this.player.transform.position.x)
            {
                transform.rotation = Quaternion.identity;
                transform.Translate(Vector2.left * this.enemySpeed * Time.deltaTime, Space.World);
            }
            else if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("Golem_Die") ^
                     anim.GetCurrentAnimatorStateInfo(0).IsName("Golem_app")))
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
                transform.Translate(Vector2.right * this.enemySpeed * Time.deltaTime, Space.World);
            }
        }
        else
        {
            if (transform.position.x < startPosition.x)
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else 
            {
                transform.rotation = Quaternion.identity;
            }
            transform.position = Vector2.MoveTowards(transform.position, startPosition, enemySpeed * Time.deltaTime);
        }
        
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x > this.player.transform.position.x)
        {
            playerVisible = Physics2D.Raycast(transform.position, Vector2.left, distance, 1 << player.layer);
            Debug.DrawRay(transform.position, Vector2.left * distance);
        }          
        else
        {
            playerVisible = Physics2D.Raycast(transform.position, Vector2.right, distance, 1 << player.layer);
            Debug.DrawRay(transform.position, Vector2.right * distance);
        }
            
    }

    IEnumerator Attack()
    {
        while(attackFlag)
        {
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
            var playerDirection = Mathf.Sign(player.transform.position.x - transform.position.x);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerDirection * Vector2.one.x, 0f) * backForcePlayer);
            player.GetComponent<MyPlayerControl>().Demage();
        }
        
    }
}
