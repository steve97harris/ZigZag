using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level01");
        
    }

    public void Stats()
    {
        SceneManager.LoadScene("Stats");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

