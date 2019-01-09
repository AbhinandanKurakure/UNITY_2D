using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {


    //cached reference

   // [SerializeField] Ball ballVar;
    [SerializeField]public int Life=3;
    

    private void Awake()
    {
       int losecollider = FindObjectsOfType<LoseCollider>().Length;
        Life = 3;
        if (losecollider > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
    
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        Life--;

        if (Life < 1)
        {
            SceneManager.LoadScene("Game Over");
            Life = 3;
            
        }
        else
        {

            Ball ballVar = FindObjectOfType<Ball>(); //Set the Ball back to paddle position
            ballVar.LockBallToPaddle();
        }

    }
}


