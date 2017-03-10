﻿using UnityEngine;
using System.Collections;

public class Ball_Controller : MonoBehaviour 
{

	// TODO: Use Mathf.clamp to prevent the ball from exceeding a certain location
	// OR reset level when ball enters a certain location in the transform

	// TODO: Create particles emitting the opposite direction of the balls movment
	// to create a trail

	// Public Variables	
	public float ballSpeed 		= 10.0f;
	public float maxBallSpeed 	= 25.0f;
	public float ballSpeedRate 	= 0.5f;
	
	public bool ballSpeedIncrease = false;
	
	// Private Variables
	private Rigidbody2D rb;
	
	
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	
	// Start function
	void Start () 
	{
		float defBallSpeed;			// Default value for ball speed
		
		defBallSpeed = ballSpeed;	// Sets the default value to == the current ballSpeed
		
		reset(defBallSpeed);
	}
	
	public void reset(float defBallSpeed)
	{
		ballSpeed = defBallSpeed;
		
		transform.position = new Vector3(0, 1); 	// Sets ball position upon reset
		
		rb.velocity = Vector2.right * ballSpeed;	// Launches ball to the right
		//TODO: If Red wins, launch ball towards blue, if blue wins, launch ball towards red
		
	}
	
	// Ball hitfactor in relation to paddle 
	// Depends on what part of the paddle is hit by the ball
 	float hitfactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
	{
		// ascii art:
        //||  1 <- at the top of the racket
        //||
        //||  0 <- at the middle of the racket
        //||
        //|| -1 <- at the bottom of the racket
		
		return (ballPos.y - paddlePos.y) / paddleHeight;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
		
		
		
		if (col.gameObject.tag == "Left Paddle" || col.gameObject.tag == "Left Brick") 	// If ball hit the left paddle...
		{
			
			// If ballSpeecIncrease is enabled and ball speed is less than max ball speed...
			if (ballSpeedIncrease == true && ballSpeed < maxBallSpeed)
			{
				ballSpeed += ballSpeedRate; // Increase ball speed by 1 every hit of the paddle
			}
			
			// Calculate Hit Factor
			float y = hitfactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			
			// Calculate direction, make length = 1 via .normalized
			Vector2 dir = new Vector2 (1, y).normalized;
			
			// Set velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
		}



		// If ballSpeecIncrease is enabled and ball speed is less than max ball speed...
		if (col.gameObject.tag == "Right Paddle" || col.gameObject.tag == "Right Brick")	// If ball hit the right paddle...
		{
			if (ballSpeedIncrease == true && ballSpeed < maxBallSpeed)
			{
				ballSpeed += ballSpeedRate; // Increase ball speed by 1 every hit of the paddle
			}
			
			// Calculate Hit Factor
			float y = hitfactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			
			// Calculate direction, make length = 1 via .normalized
			Vector2 dir = new Vector2(-1, y).normalized;
			
			// Set velocity with dir * speed;
			GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
		}
			
	}
}