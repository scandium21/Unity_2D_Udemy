using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Track mouse position in terms of Unity unit
        // 16 is the total width of game camera 
        // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        float mousePosInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        // Creates a Vector2 to track x and y coordinates
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        // Set the range of the x movement
        paddlePos.x = Mathf.Clamp(mousePosInUnit, minX, maxX);

        transform.position = paddlePos;
    }
}
