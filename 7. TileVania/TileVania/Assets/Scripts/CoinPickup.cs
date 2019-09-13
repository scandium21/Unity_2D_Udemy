using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // config parameters
    [SerializeField] AudioClip coinPickupSFX;
    bool collided = false;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        //CountCoins();
    }

    private void CountCoins()
    {
        level.CountCoins();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<CoinPickup>().collided) { return;  }
        
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddScore(1);
        level.CoinCollected();
        collided = !collided;
    }


}
