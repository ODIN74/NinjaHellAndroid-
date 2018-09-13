using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraFollow : MonoBehaviour {

    public float MaxOffset;

    public float MaxX;

    public float MinX;

    public float CameraSpeed;

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("hero");		
	}
	
	// Update is called once per frame
	void Update () {

        var targetX = transform.position.x;

        if (Mathf.Abs(transform.position.x - player.transform.position.x) > MaxOffset)
        {
            targetX = Mathf.Clamp(player.transform.position.x, MinX, MaxX);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), CameraSpeed * Time.deltaTime);
        }

    }
}
