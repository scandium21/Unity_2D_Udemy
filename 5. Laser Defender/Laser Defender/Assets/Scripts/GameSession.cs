using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // state variable
    int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType(GetType()).Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }


    public void AddToScore(int scoreValue)
    {
        currentScore += scoreValue;
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
