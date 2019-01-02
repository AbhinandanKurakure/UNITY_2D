using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;

    //cached Reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableObjects();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
