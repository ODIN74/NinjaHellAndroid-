using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailFingerPoint : MonoBehaviour {

    public GameObject FingerPointObject;

    private RectTransform parentRT;

    private void Start()
    {
        parentRT = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<RectTransform>();
        Debug.Log(parentRT);
    }
    // Update is called once per frame
    void Update()
    {
		if(Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                CreateFingerPoint(Input.mousePosition);
            }
        }
	}

   

    void CreateFingerPoint(Vector3 position)
    {
        Instantiate(FingerPointObject, CreateScreenPosition(position), Quaternion.identity);
    }

    private Vector3 CreateScreenPosition(Vector3 mausePosition)
    {
        var coefficient = (float)Screen.height / (Camera.current.orthographicSize * 2f);
        var x = ((mausePosition.x - parentRT.position.x) /  coefficient) + Camera.current.transform.position.x;
        var y = (mausePosition.y - parentRT.position.y) / coefficient;

        return new Vector3(x,y, -1f);
    }
}
