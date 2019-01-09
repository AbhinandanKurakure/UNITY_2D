using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breakableObjects; // serializing just for debugging through inspector

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
            sceneloader.LoadNextScene();
        }
    }
}
