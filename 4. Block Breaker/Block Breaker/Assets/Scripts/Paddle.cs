using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // cached references
    GameSession myGameSession;
    Ball myBall;

    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // Track mouse position in terms of Unity unit
        // 16 is the total width of game camera 
        // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);

        // Creates a Vector2 to track x and y coordinates
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        // Set the range of the x movement
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePos;
    }

    // Enable autoplay feature
    private float GetXPos()
    {
        if(myGameSession.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
