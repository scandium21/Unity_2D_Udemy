using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        // Show the name of the object collided into ME
        // Debug.Log(collision.gameObject.name);
    }

}
