using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float unityUnits=16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    float mousePosInUnits;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        mousePosInUnits=Input.mousePosition.x/Screen.width * unityUnits;
       
        Vector2 paddlePos = new Vector2(mousePosInUnits ,transform.position.y);
        paddlePos.x=Mathf.Clamp(paddlePos.x, minX, maxX);
        transform.position = paddlePos;
	}
}
