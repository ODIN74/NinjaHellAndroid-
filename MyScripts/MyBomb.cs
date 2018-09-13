using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class MyBomb : MonoBehaviour {

    public float bombTimer;

    public AudioClip CreateBomb;

    public AudioClip BangBomb;

    public float backForce;

    public Animation BangAnimation;

    private Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") Bang();
    }

    // Use this for initialization
    void Start ()
    {
        AudioSource.PlayClipAtPoint(CreateBomb, transform.position);
        anim = GetComponent<Animator>();
        StartCoroutine(BombTimer());
	}

    IEnumerator BombTimer()
    {
        yield return new WaitForSecondsRealtime(7f);
        anim.SetTrigger("Bang");
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }

    void Bang()
    {
        var enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        var player = GameObject.Find("hero");
            anim.SetTrigger("Bang");

        foreach (var obj in enemyArray)
        {
            var direction = Mathf.Sign(obj.transform.position.x - transform.position.x);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction * Vector2.one.x, 0f) * backForce);
        }
        var playerDirection = Mathf.Sign(player.transform.position.x - transform.position.x);
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerDirection * Vector2.one.x, 0f) * backForce * 5);

        Destroy(gameObject,anim.GetCurrentAnimatorStateInfo(0).length);
    }

}
