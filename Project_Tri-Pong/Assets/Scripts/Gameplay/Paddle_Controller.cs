using UnityEngine;
using System.Collections;

public class Paddle_Controller : MonoBehaviour 
{
	// Public Variables
	// List of Game Paddles
	[Header("List of Game Paddles")]
	public Transform[] gamePaddles; 	// Stores a list of paddles in the game scene


	// Paddle Atributes
	[Header("Paddle Atributes")]
	public float paddleSpeed 	= 30.0f; 		// The speed the paddles will move
	public float maxHeight = 4.0f;
	public float minHeight = -4.0f;

	///////////////////////
	// Private Variables //
	///////////////////////

	// Paddle Controller
	private string paddleAxis 	= "Vertical";	// The axis the paddles will move
	private Vector3 paddlePos;

	// Paddle Physics
	private Rigidbody2D paddleRB2D;				// Reference to the RigidBody2D Component
	
	// Upon the object being created
	void Awake()
	{
		// Creates an instance of the RigidBody2D object
		paddleRB2D = GetComponent<Rigidbody2D>();
	}
	

	/*
	 * TODO: Attach this script to the controller parent object, use obejct to control each of the paddles individually.
	 * Each paddle corresponds to a location in the array:
	 * 0: L_Paddle_1
	 * 1: L_Paddle_2
	 * 2: L_Paddle_3
	 * 3: R_Paddle_1
	 * 4: R_Paddle_2
	 * 5: R_Paddle_3
	 */
	// Updates every fixed frame
	void FixedUpdate()	
	{
		// Defines the paddlemovement
		float moveInput = Input.GetAxisRaw(paddleAxis);
			
			
		// Tells the rigidbody component to move the gameobject
		//gamePaddles[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0 , moveInput) * paddleSpeed;
		gamePaddles[0].transform.Translate(0, moveInput * (paddleSpeed * 0.25f), 0);

		// Gets the current paddle position
		paddlePos = gamePaddles[0].transform.position;

		// Sets the clamp of the paddle between 2 values
		paddlePos.y = Mathf.Clamp(paddlePos.y, minHeight, maxHeight);

		// Updates the current paddle's position
		gamePaddles[0].transform.position = paddlePos;

		
		
	}
}
