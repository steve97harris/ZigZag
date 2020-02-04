using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score",score);
    }

    void Update()
    {
        
    }

    void incrementScore()
    {
        score += 1;
    }

    public void startScore()
    {
        InvokeRepeating("incrementScore",0.1f, 0.5f);        // Invoke increment score at 0.1 seconds and repeat every 0.5 
    }

    public void StopScore()
    {
        CancelInvoke("startScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score); 
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
