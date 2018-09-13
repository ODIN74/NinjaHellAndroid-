using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRocketSpawner : MonoBehaviour {

    public GameObject TurretRocket;

    public float Distance = 30f;

    private int playerLayer;

    private RaycastHit2D hit;

    private HingeJoint2D turretHJ2D;

    private bool turretSeeToPlayer = false;

	// Use this for initialization
	void Start () {
        playerLayer = 1 << GameObject.Find("hero").layer;
        turretHJ2D = gameObject.GetComponentInParent<HingeJoint2D>();
    }
	
	void FixedUpdate ()
    {
        hit = Physics2D.Raycast(gameObject.gameObject.transform.position, -Vector2.right, Distance, playerLayer);
        Debug.DrawRay(gameObject.gameObject.transform.position, -Vector2.right * Distance, Color.red);
        if(hit.collider != null)
        {
            Debug.DrawRay(gameObject.gameObject.transform.position, -Vector2.right * Distance, Color.blue);
            turretHJ2D.useMotor = true;
            if (!turretSeeToPlayer)
            {
                turretSeeToPlayer = true;
                StartCoroutine(TurretFire());
            }          
        }
        else
        {
            turretSeeToPlayer = false;
            StopCoroutine(TurretFire());                
        }
	}

    IEnumerator TurretFire()
    {
        while(turretSeeToPlayer)
        { 
            yield return new WaitForSecondsRealtime(2f);
            Instantiate(TurretRocket, transform);
        }
    }
}
