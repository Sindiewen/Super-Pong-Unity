using UnityEngine;
using System.Collections;

public class Paddle_Controller : MonoBehaviour 
{
	// Public Variables
	public float paddleSpeed 	= 30.0f; 		// The speed the paddles will move

	// Private Variables
	private string paddleAxis 	= "Vertical";	// The axis the paddles will move
	
	
	// Updates every fixed frame
	void FixedUpdate()
	{
		// Defines the paddlemovement
		float moveInput = Input.GetAxisRaw(paddleAxis);
			
		// Tells the rigidbody component to move the gameobject
		GetComponent<Rigidbody2D>().velocity = new Vector2(0 , moveInput) * paddleSpeed;
		
	}
}
