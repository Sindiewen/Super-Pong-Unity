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
	
	// Use this for initialization
	void Start () 
	{
		// Initializes the score values to 0
		leftScore = rightScore = winScore = 0;

		// Sets the initial score to be 0
		leftText.text 	= (leftScore.ToString());
		rightText.text 	= (rightScore.ToString());
		
	}




	public void LeftScore()
	{

		// Iterates the score by 1
		leftScore++;

		// Adds 1 to the score
		leftText.text = (leftScore.ToString());

		// DEBUG - Left Side Scored
		Debug.Log("Left Side Scored");
			
		if (leftScore == winScore)
		{
			// Left side wins
		}
		
	}

	public void leftSideGoal()
	{
		// Left side won
		ball.Explode();

		// TODO: Print to screen the left side has won
	}
	
	public void RightScore()
	{
		// Iterates score by 1
		rightScore++;
		
		// Adds 1 to the score
		rightText.text = (rightScore.ToString());

		// DEBUG - Right Side Scored
		Debug.Log("Right Side Scored");
			
		if (rightScore == winScore)
		{
			// Right side wins
		}
		
	}

	public void RightSideGoal()
	{
		// Right side won
		ball.Explode();

		// TODO: Print to screen the right side has won
	}

}


