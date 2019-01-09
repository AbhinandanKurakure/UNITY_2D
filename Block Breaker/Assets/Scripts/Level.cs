using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] int breakableObjects; // serializing just for debugging through inspector
   // [SerializeField] Ball ball;
   // [SerializeField] Block block;


    //cached reference
    [SerializeField] SceneLoader sceneloader;
    
   

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableObjects()
    {
        breakableObjects++;
    }

    public void DestroyedBlocks()
    {
        breakableObjects--;

        if(breakableObjects<=0)
        {
            Block block;
            block = FindObjectOfType<Block>();
            block.timesHit = 0;

            Ball ball;
            ball = FindObjectOfType<Ball>();
            ball.LockBallToPaddle();
            sceneloader.LoadNextScene();
        }
    }
}
