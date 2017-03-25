using UnityEngine;
using System.Collections;

public class Ball_Controller : MonoBehaviour 
{

	// TODO: Use Mathf.clamp to prevent the ball from exceeding a certain location
	// OR reset level when ball enters a certain location in the transform

	// TODO: Create particles emitting the opposite direction of the balls movment
	// to create a trail

	// Public Variables	
	[Header ("Ball Speed Values")]
	public float ballSpeed 		= 10.0f;	// The ball's current speed
	public float ballSpeedModified;
	public float maxBallSpeed 	= 25.0f;	// The ball's maximum speed
	public float ballSpeedRate 	= 0.5f;		// The interval in which how fast the speed will increase every hit
	
	public bool ballSpeedIncrease = false;	// Weather the ball increases every hit or not
	
	public Score_Controller Score_Controller;

	// Private Variables
	
	private float defBallSpeed;			// Default value for ball speed


	private Rigidbody2D rb2D;	// Reference to the rigidbody
	
	// Initializes the RNG values
	private int xRNG;
	private float yRNG;


	void Awake()
	{
		// Initializes the rigidbody of the ball
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	
	// Start function
	void Start () 
	{
		// Sets the default value to == the current ballSpeed
		defBallSpeed = ballSpeed;	
		
		// Resets the ball to start moving upon game start
		StartCoroutine(Initialize());

		
	}
	
	IEnumerator Initialize()
	{
		// Generates 2 random numbers for the x and y axis
		do
		{
			xRNG = (int)Random.Range(-1.0f, 1.0f);
			yRNG = Random.Range(-1.0f, 1.0f);
		}
		while (xRNG == 0 || yRNG == 0);
	
		// Game starts text shows
		Score_Controller.leftWinText.text = ("Game Start!");
		
		// Sets the ball speed to the default ball speed
		ballSpeed = defBallSpeed;
		
		// Sets the transform to it's initial position
		transform.position = new Vector3(0, 0); 	// Sets ball position upon reset
	
		// Wait a moment before launching the ball
		yield return new WaitForSeconds(2.0f);
		
		// Empties the win text
		Score_Controller.leftWinText.text = ("");
		
	
		
		rb2D.velocity = new Vector2(xRNG, yRNG) * ballSpeed;	// Launches ball to the right
		Debug.Log("Random velocity: X = " + xRNG + " Y = " + yRNG);
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
		
		
		
		if (col.gameObject.tag == "Left Normal Paddle" || col.gameObject.tag == "Left Brick") 	// If ball hit the left paddle...
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
			rb2D.velocity = dir * ballSpeed;

			if (col.gameObject.tag == "Left Brick")
			{
				// Gives 1 point to the left side
				//Score_Controller.RightScore();
			}
		}

		if (col.gameObject.tag == "Left Arc Paddle")
		{
			if (ballSpeedIncrease == true && ballSpeed < maxBallSpeed)
			{
				ballSpeed += ballSpeedRate ; // Increase ball speed by 1 every hit of the paddle
			}
			
			// Calculate Hit Factor
			float y = hitfactor(transform.position, col.transform.position, col.collider.bounds.size.y) ;
			
			// Calculate direction, make length = 1 via .normalized
			Vector2 dir = new Vector2(-1, y).normalized;
			
			// Set velocity with dir * speed;
			rb2D.velocity = dir * (ballSpeed * 2);
		}

		if (col.gameObject.tag == "Right Goal")
		{
			// left scores
			Score_Controller.LeftScore();
			Score_Controller.leftSideGoal();
		}


		// If ballSpeecIncrease is enabled and ball speed is less than max ball speed...
		if (col.gameObject.tag == "Right Normal Paddle" || col.gameObject.tag == "Right Brick")	// If ball hit the right paddle...
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
			rb2D.velocity = dir * ballSpeed;
			
			
			if (col.gameObject.tag == "Right Brick")
			{
				// Gives 1 point to the left side
				//Score_Controller.LeftScore();
			}
		}

		if (col.gameObject.tag == "Right Arc Paddle")
		{
			if (ballSpeedIncrease == true && ballSpeed < maxBallSpeed)
			{
				ballSpeed += ballSpeedRate; // Increase ball speed by 1 every hit of the paddle
			}
			
			// Calculate Hit Factor
			float y = hitfactor(transform.position, col.transform.position, col.collider.bounds.size.y) ;
			
			// Calculate direction, make length = 1 via .normalized
			Vector2 dir = new Vector2(-1, y).normalized;
			
			// Set velocity with dir * speed;
			rb2D.velocity = dir * (ballSpeed * 2);
		}

		if (col.gameObject.tag == "Left Goal")
		{
			// Right scores
			Score_Controller.RightScore();
			Score_Controller.RightSideGoal();
		}
			
	}
	

	public IEnumerator Explode()
	{
		this.gameObject.SetActive(false);
		/* TODO:
		* Explode Ball when ball touches the goal
		*/
		yield return new WaitForSeconds(1f);
		// Reinitializes the ball
		this.gameObject.SetActive(true);
		StartCoroutine(Initialize());
	}

	
}