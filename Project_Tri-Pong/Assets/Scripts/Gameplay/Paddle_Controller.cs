using UnityEngine;
using System.Collections;

public class Paddle_Controller : MonoBehaviour 
{
	// Public Variables
	public float paddleSpeed 	= 30.0f; 		// The speed the paddles will move
	public float maxHeight = 4.0f;
	public float minHeight = -4.0f;

	// Private Variables
	private string paddleAxis 	= "Vertical";	// The axis the paddles will move
	private Rigidbody2D paddleRB2D;
	
	// Upon the object being created
	void Awake()
	{
		// Creates an instance of the RIgidBody2D object
		paddleRB2D = GetComponent<Rigidbody2D>();
	}
	
	// Updates every fixed frame
	void FixedUpdate()
	{
		// Defines the paddlemovement
		float moveInput = Input.GetAxisRaw(paddleAxis);
			
			
		// Tells the rigidbody component to move the gameobject
		paddleRB2D.velocity = new Vector2(0 , moveInput) * paddleSpeed;


		Mathf.Clamp(transform.position.y, minHeight, maxHeight);		
		
	}
}
