using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    //config param
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed=15;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] Text textvar;
    [SerializeField] LoseCollider loseColliderVar;
    [SerializeField] TextMeshProUGUI TextMeshlifeVar;
    

    //state varaiables
    [SerializeField] int currentScore=0;
    string sceneName;
    
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
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("now in start of Gamestatus Value of Life="+ loseColliderVar.Life.ToString());
        TextMeshlifeVar.text = "Life:"+loseColliderVar.Life.ToString();
        scoretext.text = "0";
        
    }

    // Update is called once per frame
    void Update () {
        sceneName = SceneManager.GetActiveScene().name;
       
        
        if (sceneName == "Game Over")
        {
            
            loseColliderVar.Life = 3;
            scoretext.text = "Final Score:" + currentScore.ToString();
            textvar.text = " ";

        }
        else
        {
            TextMeshlifeVar.text = "Life:" + loseColliderVar.Life.ToString();

            Time.timeScale = gameSpeed;
        }
	}
    
    
    public void AddToScore()
    {
        

        


        currentScore += pointsPerBlockDestroyed;
        scoretext.text = currentScore.ToString();
    }

    public void SelfDestroy()
    {
        loseColliderVar.SelfDestruct();
        Destroy(gameObject);
        
    }

    public bool IsAutoPlayEnabled()
    {
        return (isAutoPlayEnabled);
    }

    
}
