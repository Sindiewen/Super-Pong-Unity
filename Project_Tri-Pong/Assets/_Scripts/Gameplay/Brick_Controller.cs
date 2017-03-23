using UnityEngine;
using System.Collections;

public class Brick_Controller : MonoBehaviour
{
	
	// Public Variables
	public float brickRespawn       = 15f; 	// Brick respawn timer
    public int PowerupSpawnChance   = 25;   // The chance for a powerup to spawn from a brick

    // Public Powerup Object Holder
    // Stores references to the powerups that will be spawned
    public GameObject[] powerupHolder = new GameObject[5];


	// Private Variables --- DO NOT EDIt
	private SpriteRenderer sprite;			// Reference to the SpriteRenderer
	private BoxCollider2D box;				// Reference to the box collider

    // RNG Number Holder
    private int RNGNumber;                  // Stores a random number

	private float brickDespawn = 0.02f;		// Brick despawn timer

	
	void Start () 
	{
		sprite	= GetComponent<SpriteRenderer>();	// Reference to the SpriteRenderer
		box 	= GetComponent<BoxCollider2D>();	// Ensures the box collider is on the gameObject
	}
	
	void BrickToggle()
	{
		sprite.enabled  = !sprite.enabled;  // Toggles the Sprite rendered component
		box.enabled     = !box.enabled;		// Toggles the box collider Component
	}
	
	void OnCollisionEnter2D(Collision2D col)	// When a ball collides to the brick...
	{
        // Generates a random number between 0 and 100
        RNGNumber = (int)Random.Range(0, 100);
        Debug.Log("RNGNumber = " + RNGNumber);

        // IF the random number generated is less then or equal to the spawn chance
        if (RNGNumber <= PowerupSpawnChance)
        {
            // Initiate powerup spawning
            Debug.Log("Spawning Powerup");

            // Generating a new random number between 0 and the length of the Powerupholder array
            RNGNumber = (int)Random.Range(0, powerupHolder.Length);
            
            // Spawn a powerup between the length of the powerup holder array
            switch(RNGNumber)
            {
                case 0:
                    Debug.Log("Spawning Paddle Resize");
                    // Instantiate the Paddle Resize Powerup
                    break;


                case 1:
                    Debug.Log("Spawning Paddle Ascii");
                    break;


                case 2:
                    Debug.Log("Spawning Powershot");
                    break;


                case 3:
                    Debug.Log("Spawning Fast Paddle");
                    break;


                case 4:
                    Debug.Log("Spawning Extra Pall");
                    break;
            }
            // TODO: Generate a second number between 0 and powerupHolder.Length to
            // choose what powerup to spawn
        }

        if (col.gameObject.tag == "Ball")
        {
            // Disabled the brick for a period of time
		    Invoke("BrickToggle", brickDespawn);
	    	
		    // Respawns the brick after a period of time
		    Invoke("BrickToggle", brickRespawn); // Respawns the brick that was previously disabled
        }
        

		
	}

    // TODO: When the ball object collides with a brick, have a percentage chance for the brick to
    // spawn a powerup
		
}