using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
     
    
    //cached Reference
    Level level;
    GameStatus gamestatus;

    //state variables
    [SerializeField] int timesHit; //Seralized Only to Debug

    private void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        if(tag=="Breakable")
        {
            level.CountBreakableObjects();
        }
    }
        


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit == maxHits)
            {
                HandleHits();//function that determines what happens when you reached max hits

            }
            else
            {
                showNextSprite();
            }
        }
    }

    private void showNextSprite()
    {
        if (hitSprites[timesHit - 1] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1]; //bcoz array starts with 0 and timeshit startd with 1
        }
        else
        {
            Debug.LogError("Sprite size and sprites assigned in inspector is mismatched/missing"+"Gameobject Name:"+gameObject.name);
        }
    }

    private void HandleHits()
    {
        level.DestroyedBlocks();//call level class destroyedblocks function to calulate remaining Blocks
        TriggerSparklesVFX(); // To Trigger the VFx
        Destroy(gameObject); //Destroy the Current Game Object when Collision occurs
        BlockDestroySFX(); //function call
    }

    private void BlockDestroySFX()
    {
        gamestatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
