using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    //public  Text textComponent; or instead of "public" use [SerializedField]

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State currentState;    //Here State is a Class Name

    // Use this for initialization
    void Start () {
        
        currentState = startingState;
        textComponent.text = currentState.GetStateStory();
    }
	
	// Update is called once per frame
	void Update () {
        ManageStates();
		
	}

    private void ManageStates()
    {
        
        var nextStates = currentState.GetNextStates();

        for( int index=1;index<=nextStates.Length;index++)
        {
            if (Input.GetKeyDown(index.ToString() ))
            {
                
                currentState = nextStates[index-1];

            }
        }
    
        
        textComponent.text = currentState.GetStateStory();
    }
}
