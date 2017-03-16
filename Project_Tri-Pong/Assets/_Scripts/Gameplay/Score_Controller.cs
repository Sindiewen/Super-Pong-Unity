using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Controller : MonoBehaviour 
{
	// Public Variables

	// Ball Objects
	[Header ("Ball Objects")]
	public Ball_Controller ball;

	// Goal Objects	
	[Header ("Goal Objects")]
	public GameObject leftGoal;		// Reference to the leftGoal
	public GameObject rightGoal;	// Reference to the rightGoal
	
	//UI Text Objects
	[Header ("Text Objects")]
	public Text leftText;			// Reference to the left side Text
	public Text rightText;			// Reference to the right side text; 
	
	[Header ("Score")]
	public int winScore;


	// Private
	
	// Goal Iterators
	private int leftScore;
	private int rightScore;
	
	// Collider references
	private Collider2D ballCol;
	private Collider2D leftGoalCol;
	private Collider2D rightGoalCol;

	// Use this for initialization
	void Start () 
	{
		// Initializes the score values to 0
		leftScore = rightScore = winScore = 0;

		// Sets the initial score to be 0
		leftText.text 	= (leftScore.ToString());
		rightText.text 	= (rightScore.ToString());
		
		// Gets the colliders for the ball, and the goals
		ballCol 		= ball.GetComponent<Collider2D>();
		leftGoalCol		= leftGoal.GetComponent<Collider2D>();
		rightGoalCol	= rightGoal.GetComponent<Collider2D>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Checks if the ball collided with the left goal
		if (leftGoalCol.IsTouching(ballCol))
		{
			ball.Explode();

			// Iterates the score by 1
			leftScore++;

			// Adds 1 to the score
			leftText.text = (leftScore.ToString());

			// DEBUG - Left Side Scored
			Debug.Log("Left Side Scored");
			
			/* Checks if the game has been won on the left side */
			if (leftScore == winScore)
			{
				// Left side won
			}
		}
		if (rightGoalCol.IsTouching(ballCol))
		{
			ball.Explode();

			// Iterates score by 1
			rightScore++;
			
			// Adds 1 to the score
			rightText.text = (rightScore.ToString());

			// DEBUG - Right Side Scored
			Debug.Log("Right Side Scored");
			
			/* Checks if the game has been won on the right side */
			if (rightScore == winScore)
			{
				// Right side won

			}
		}
	}
	

}
