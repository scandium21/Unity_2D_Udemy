using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Load up the Game Over scene using string reference
        SceneManager.LoadScene("Game Over");
        //FindObjectOfType<GameStatus>().ResetScore();
    }
}
