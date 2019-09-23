using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGame : MonoBehaviour
{
    public static GameManagerGame instance;

    private const string HIGH_SCORE = "High score";

    void Awake()
    {
        _MakeSingleInstance();
        IsGameStartedForTheFirstTime();
    }

    // Ham dat gia tri khi bat dau game
    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("StartGameFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("StartGameFirstTime", 0);
            PlayerPrefs.SetInt("Enemy", 1);
            PlayerPrefs.SetInt("Clound", 1);
        }
    }
    void _MakeSingleInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);        }

    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
