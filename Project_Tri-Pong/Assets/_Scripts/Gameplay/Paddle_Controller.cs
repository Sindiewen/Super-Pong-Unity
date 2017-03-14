using UnityEngine;
using System.Collections;

public class Paddle_Controller : MonoBehaviour 
{
	// Public Variables

	//////////////
	// Gameplay //
	//////////////
	
	[Header ("Gameplay System")]
	// Selection to choose how many players in the game between 1 - 6, 0 being AI only
	// Defaults to AIOnly
	public Paddle_Controller_Catalog._PlayersInGame PlayersInGame = Paddle_Controller_Catalog._PlayersInGame.AIOnly;

	// List of Game Paddles
	[Header("List of Game Paddles")]
	public Transform[] gamePaddles; 	// Stores a list of paddles in the game scene


	// Paddle Atributes
	[Header("Paddle Atributes")]
	public float paddleSpeed 	= 3.0f; 		// The speed the paddles will move
	public float maxHeight = 4.0f;
	public float minHeight = -4.0f;

	///////////////////////
	// Private Variables //
	///////////////////////

	// Paddle Controller
	

	// Defines the paddlemovement axis
	float moveInputL1;
	float moveInputL2;
	float moveInputL3;
	float moveInputR1;
	float moveInputR2;
	float moveInputR3;
			

	private string paddleAxisL1;	// The axis the paddles will move
	private string paddleAxisL2;	// The axis the paddles will move
	private string paddleAxisL3;	// The axis the paddles will move
	private string paddleAxisR1;	// The axis the paddles will move
	private string paddleAxisR2;	// The axis the paddles will move
	private string paddleAxisR3;	// The axis the paddles will move
	

	private Vector3 paddlePosL1;	// Stores the current paddle position
	private Vector3 paddlePosL2;	// Stores the current paddle positionp
	private Vector3 paddlePosL3;	// Stores the current paddle position
	private Vector3 paddlePosR1;	// Stores the current paddle position
	private Vector3 paddlePosR2;	// Stores the current paddle position
	private Vector3 paddlePosR3;	// Stores the current paddle position



	// Runs at the start of the scene
	void Start()
	{
		// Initialize the paddle axis names
		paddleAxisL1 	= "VerticalL1";	
		paddleAxisL2 	= "VerticalL2";	
		paddleAxisL3 	= "VerticalL3";	
		paddleAxisR1 	= "VerticalR1";	
		paddleAxisR2 	= "VerticalR2";
		paddleAxisR3 	= "VerticalR3";		
	}
	

	/*
	 * TODO: Attach this script to the controller parent object, use obejct to control each of the paddles individually.
	 * Each paddle corresponds to a location in the array:
	 * 0: L_Paddle_1	// Goalie
	 * 1: L_Paddle_2	// Middle
	 * 2: L_Paddle_3	// Front
	 * 3: R_Paddle_1	// Goalie
	 * 4: R_Paddle_2	// Middle
	 * 5: R_Paddle_3	// Front
	 */
	// Updates every fixed frame
	void FixedUpdate()	
	{
		// Initializes the paddle axis
		moveInputL1 = Input.GetAxisRaw(paddleAxisL1);
		moveInputL2 = Input.GetAxisRaw(paddleAxisL2);
		moveInputL3 = Input.GetAxisRaw(paddleAxisL3);
		moveInputR1 = Input.GetAxisRaw(paddleAxisR1);
		moveInputR2 = Input.GetAxisRaw(paddleAxisR2);
		moveInputR3 = Input.GetAxisRaw(paddleAxisR3);



		// If there are 0 players in game - AIOnly
		if (PlayersInGame == Paddle_Controller_Catalog._PlayersInGame.AIOnly)
		{
			Debug.Log("No Players in game, running in AI Only Mode");
		}
		// Else if there is 1 player PlayersInGame
		else if (PlayersInGame == Paddle_Controller_Catalog._PlayersInGame.SinglePlayer)
		{
			Debug.Log("Currently 1 Player in game, Human VS AI");
			
			
			/* Control for Paddle L_Paddle_1 */
			
			// Tells the transform component to translate the object
			gamePaddles[0].transform.Translate(0, moveInputL1 * (paddleSpeed * 0.25f), 0);
			Debug.Log(moveInputL1);
			// Gets the current paddle position
			paddlePosL1 = gamePaddles[0].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosL1.y = Mathf.Clamp(paddlePosL1.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[0].transform.position = paddlePosL1;




			/* Control for Paddle L_Paddle_2 */

			// Tells the transform component to translate the object
			gamePaddles[1].transform.Translate(0, moveInputL2 * (paddleSpeed * 0.25f), 0);
			
			// Gets the current paddle position
			paddlePosL2 = gamePaddles[1].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosL2.y = Mathf.Clamp(paddlePosL2.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[1].transform.position = paddlePosL2;




			/* Control for Paddle L_Paddle_3 */

			// Tells the transform component to translate the object
			gamePaddles[2].transform.Translate(0, moveInputL3 * (paddleSpeed * 0.25f), 0);
			// Gets the current paddle position
			paddlePosL3 = gamePaddles[2].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosL3.y = Mathf.Clamp(paddlePosL3.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[2].transform.position = paddlePosL3;


		}
		// Else if there are 2 people playing 
		else if (PlayersInGame == Paddle_Controller_Catalog._PlayersInGame.TwoPlayers)
		{
			Debug.Log("Currently 2 players in game, Human VS Human");

			/* Control for Paddle L_Paddle_1 */
			
			// Tells the transform component to translate the object
			gamePaddles[0].transform.Translate(0, moveInputL1 * (paddleSpeed * 0.25f), 0);
			// Gets the current paddle position
			paddlePosL1 = gamePaddles[0].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosL1.y = Mathf.Clamp(paddlePosL1.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[0].transform.position = paddlePosL1;


			/* Control for Paddle L_Paddle_2 */

			// Tells the transform component to translate the object
			gamePaddles[1].transform.Translate(0, moveInputL2 * (paddleSpeed * 0.25f), 0);
			
			// Gets the current paddle position
			paddlePosL2 = gamePaddles[1].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosL2.y = Mathf.Clamp(paddlePosL2.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[1].transform.position = paddlePosL2;


			/* Control for Paddle L_Paddle_3 */

			// Tells the transform component to translate the object
			gamePaddles[2].transform.Translate(0, moveInputL3 * (paddleSpeed * 0.25f), 0);
			// Gets the current paddle position
			paddlePosL3 = gamePaddles[2].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosL3.y = Mathf.Clamp(paddlePosL3.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[2].transform.position = paddlePosL3;




			/* Player 2 Controls */
			/* Control for Paddle R_Paddle_1 */
			
			// Tells the transform component to translate the object
			gamePaddles[3].transform.Translate(0, moveInputR1 * (paddleSpeed * 0.25f), 0);
			// Gets the current paddle position
			paddlePosR1 = gamePaddles[3].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosR1.y = Mathf.Clamp(paddlePosR1.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[3].transform.position = paddlePosR1;


			/* Control for Paddle R_Paddle_2 */

			// Tells the transform component to translate the object
			gamePaddles[4].transform.Translate(0, moveInputR2 * (paddleSpeed * 0.25f), 0);
			
			// Gets the current paddle position
			paddlePosR2 = gamePaddles[4].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosR2.y = Mathf.Clamp(paddlePosR2.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[4].transform.position = paddlePosR2;


			/* Control for Paddle R_Paddle_3 */

			// Tells the transform component to translate the object
			gamePaddles[5].transform.Translate(0, moveInputR3 * (paddleSpeed * 0.25f), 0);
			// Gets the current paddle position
			paddlePosR3 = gamePaddles[5].transform.position;

			// Sets the clamp of the paddle between 2 values
			paddlePosR3.y = Mathf.Clamp(paddlePosR3.y, minHeight, maxHeight);

			// Updates the current paddle's position
			gamePaddles[5].transform.position = paddlePosR3;
		}
		// Else if there are 6 people playing
		else if (PlayersInGame == Paddle_Controller_Catalog._PlayersInGame.SixPlayers)
		{
			Debug.Log ("Currently 6 Players in game, 3 Humans vs 3 Humans");
		}


	
		
		
	}
}
