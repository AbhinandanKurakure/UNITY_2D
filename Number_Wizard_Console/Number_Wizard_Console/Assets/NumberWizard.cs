using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {


    int max, min, guess;


    // Use this for initialization
    void Start () {

        StartGame();
	}

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = 500;
        Debug.Log("Welcome To Number Wizard");
        Debug.Log("Pick a Number in ur Mind,and don't tell me.. ");
        Debug.Log("Highest Number u can pick is " + max);
        Debug.Log("Lowest Number u can pick is " + min);
        Debug.Log("Is your Guess is " + guess);
        Debug.Log("Up=Higher,Down=Lower,Enter=Correct");
        max = max + 1;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow Pressed");
            min = guess;
            NextGuess();
           
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow Pressed");
            max = guess;
            NextGuess();
        }

        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Hell Yeah!!!!");
            StartGame();
        }
        
    }

    void NextGuess()
    {
        guess = (min + max) / 2;
        Debug.Log("Is your guessed Number is" + guess);
        Debug.Log("Or is it Higher or Lower than this");
    }
}
