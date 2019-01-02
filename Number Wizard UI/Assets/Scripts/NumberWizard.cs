using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour {


    [SerializeField] int max, min;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;


    // Use this for initialization
    void Start () {

        StartGame();
	}

    void StartGame()
    {


        //max = max + 1;
        guess = Random.Range(min,max+1);
        
        DisplayGuess();
    }
	
	
	

   public  void OnPressHigher()
    {
        
        //    Debug.Log("Up Arrow Pressed");
            min = guess;
            NextGuess();

        
    }

    public void OnPressLower()
    {
        
            
            max = guess;
            NextGuess();

        
    }
    void NextGuess()
    {
        guess = (min + max) / 2;
        DisplayGuess();

    }

    void DisplayGuess()
    {
        guessText.text = guess.ToString();
    }
}
