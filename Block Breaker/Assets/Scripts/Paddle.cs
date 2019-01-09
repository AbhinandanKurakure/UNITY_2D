using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float unityUnits=16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;


    //cached reference
    Ball ballrb; //ball rigidbody
    GameStatus gamestatus;

    //float mousePosInUnits;

    


    // Use this for initialization
    void Start () {
        ballrb = FindObjectOfType<Ball>();
        gamestatus = FindObjectOfType<GameStatus>();

    }
	
	// Update is called once per frame
	void Update () {
        ballrb = FindObjectOfType<Ball>();
        gamestatus = FindObjectOfType<GameStatus>();
        //if(FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        // {
        //      XPos();
        //  }
        //mousePosInUnits=Input.mousePosition.x/Screen.width * unityUnits;

        Vector2 paddlePos = new Vector2(transform.position.x ,transform.position.y);

        paddlePos.x=Mathf.Clamp(XPos(), minX, maxX);
        transform.position = paddlePos;
	}

    private float XPos()
    {
        if(gamestatus.IsAutoPlayEnabled())
        {
            return ballrb.transform.position.x;
           
        }
        else
            return Input.mousePosition.x / Screen.width * unityUnits;
    }
}
