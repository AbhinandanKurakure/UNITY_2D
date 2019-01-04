using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float pushX=2f;
    [SerializeField] float pushY =15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    
    //state
    Vector2 paddleToBallVector;
    bool hasStarted =false;

    //Cached component Reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    

	// Use this for initialization
	void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	
    // Update is called once per frame
	void Update ()
    {
        if (hasStarted == false)
        {
            LockBallToPaddle();
            LaunchOnBallClick();
        }
    }

    private void LaunchOnBallClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(pushX, pushY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x, y;
        x = UnityEngine.Random.Range(0f, randomFactor);
        y = UnityEngine.Random.Range(0f, randomFactor);

        Vector2 tweakFactor = new Vector2(x,y);
        if (hasStarted == true)
        {
           // Debug.Log(collision.gameObject.name);
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += tweakFactor; //Add random force after collision so that the ball doesn't end up in a loop
        }
    }
}
