using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;

    //cached Reference
    Level level;
    GameStatus gamestatus;

    private void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.CountBreakableObjects();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gamestatus.AddToScore();
        level.DestroyedBlocks();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
