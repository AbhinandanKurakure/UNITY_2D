using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {


    //cached reference

    [SerializeField] Ball ballVar;
    [SerializeField] int Life;

    private void Awake()
    {
        int loseCollider = FindObjectsOfType<LoseCollider>().Length;

        if (loseCollider > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Life--;

        if (Life < 1)
            SceneManager.LoadScene("Game Over");
        else
        {
            //ballVar = GetComponent<Ball>(); //Set the Ball back to paddle position
            ballVar.LockBallToPaddle();
        }

    }
}


