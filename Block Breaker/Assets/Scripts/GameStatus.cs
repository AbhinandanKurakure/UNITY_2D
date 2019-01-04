using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    //config param
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed=15;
    [SerializeField] TextMeshProUGUI scoretext;
    
    //state varaiables
    [SerializeField] int currentScore=0;

    private void Awake()
    {
        int gameStatus = FindObjectsOfType<GameStatus>().Length;

        if (gameStatus > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        
        scoretext.text = "0";    
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}
    
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoretext.text = currentScore.ToString();
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
