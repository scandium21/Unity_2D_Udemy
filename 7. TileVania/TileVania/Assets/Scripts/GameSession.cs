using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI coinCount;
    [SerializeField] GameObject[] playerLifeImages;
    int score = 0;
    int startingScenenIndex;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        coinCount.text = "x 0";
        startingScenenIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("Now in scene: " + startingScenenIndex);
    }

    private void Update()
    {
        int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentScenceIndex != startingScenenIndex)
        {
            //reset score
            score = 0;
            coinCount.text = "x " + (score).ToString();
            for(int i = 0; i < playerLifeImages.Length; i++)
            {
                playerLifeImages[i].SetActive(true);
            }
            playerLives = 3;
            startingScenenIndex = SceneManager.GetActiveScene().buildIndex;
        }

    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        coinCount.text = "x " + (score).ToString();
    }


    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    private void TakeLife()
    {
        playerLifeImages[playerLives - 1].SetActive(false);
        playerLives -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
