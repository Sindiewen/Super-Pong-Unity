using UnityEngine;
using System.Collections;

public class Paddle_Controller : MonoBehaviour 
{
	public float paddleSpeed = 30.0f; 		// The speed the paddles will move
	public string paddleAxis = "Vertical";	// The axis the paddles will move
	
	

	void FixedUpdate()
	{
		
		float moveInput = Input.GetAxisRaw(paddleAxis);	// Defines the paddlemovement
			
		// Tells the rigidbody component to move the gameobject
		GetComponent<Rigidbody2D>().velocity = new Vector2(0 , moveInput) * paddleSpeed;
		
	}
}
