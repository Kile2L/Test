using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
   
    // GameObject
    public GameObject playerObject;
    private Rigidbody2D rigidbody2D;
    // Use this for initialization
    void Start()
    {
        // Create a force
        ballInitialForce = new Vector2(100.0f, 300.0f);
        // Set to inactive
        ballIsActive = false;
        // Ball position
        ballPosition = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input
        if (Input.GetButtonDown("Jump") == true)
        {
            // check if is the first play
            if (!ballIsActive)
            {
                rigidbody2D.velocity = Vector2.zero;
                // Add of force
                rigidbody2D.AddForce(ballInitialForce);
                // Set ball active
                ballIsActive = !ballIsActive;
            }
        }

        if (!ballIsActive && playerObject != null){
            // Get and use the player position
            ballPosition.x = playerObject.transform.position.x;
            // Apply player X position to the ball
            transform.position = ballPosition;
        }
        // Check if ball falls
        if (ballIsActive && transform.position.y <= -6) {
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -4.05f;
            transform.position = ballPosition;
            playerObject.SendMessage("TakeLife");
        }
        
    }
}