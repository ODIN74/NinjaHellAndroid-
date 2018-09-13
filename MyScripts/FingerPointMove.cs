using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerPointMove : MonoBehaviour {

    private Vector3 positionAtLastFrame;

    private void Start()
    {
        positionAtLastFrame = gameObject.GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update () {
		if(Input.touches[0].phase == TouchPhase.Moved)
        {
            var coefficient = (float)Screen.height / (Camera.current.orthographicSize * 2f);
            var minX = Camera.current.transform.position.x - Camera.current.orthographicSize * Screen.width / Screen.height;
            var maxX = Camera.current.transform.position.x + Camera.current.orthographicSize * Screen.width / Screen.height;
            var minY = Camera.current.transform.position.y - Camera.current.orthographicSize;
            var maxY = Camera.current.transform.position.y + Camera.current.orthographicSize;
            var x = Mathf.Clamp(positionAtLastFrame.x + Input.GetTouch(0).deltaPosition.x * Input.GetTouch(0).deltaTime, minX, maxX);
            var y = Mathf.Clamp(positionAtLastFrame.y + Input.GetTouch(0).deltaPosition.y * Input.GetTouch(0).deltaTime, minY, maxY);
            gameObject.GetComponent<RectTransform>().position = positionAtLastFrame = new Vector3(x, y, -1f);
        }

        if(Input.touches[0].phase == TouchPhase.Ended)
        {
            Destroy(gameObject);
        }
	}
}
