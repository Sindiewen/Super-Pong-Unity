using UnityEngine;
using System.Collections;

public class Brick_Controller : MonoBehaviour
{
	
	// Public Variables
	[Header ("Brick Respawn Values")]
	public float brickRespawn               = 15f; 	    // Brick respawn timer
	public float SpawnTimerRateIncrease     = 2f;     // The rate in which the brick respawn lengthens
    public  bool CanIncreaseSpawnTimer      = false;    // Weather the spawn timer can increase  

    // Powerup Variables
    [Header ("Powerup Values")]
    public int PowerupSpawnChance   = 50;   // The chance for a powerup to spawn from a brick

    // Public Powerup Object Holder
    // Stores references to the powerups that will be spawned
    public GameObject[] powerupHolder = new GameObject[5];


	// Private Variables --- DO NOT EDIT
	private SpriteRenderer sprite;			// Reference to the SpriteRenderer
	private BoxCollider2D box;				// Reference to the box collider
    
    private GameObject powerupClone;


    // Random Number Generator Values
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
		
		// If the bricks spawn timer can be increased
        if (CanIncreaseSpawnTimer)
        {
            // Increase the spawn timer by a set Value
            brickRespawn += SpawnTimerRateIncrease;
        } 
	}
	
	void OnCollisionEnter2D(Collision2D col)	// When a ball collides to the brick...
	{
        // Generates a random number between 0 and 100
        RNGNumber = (int)Random.Range(0, 100);
        //Debug.Log("RNGNumber = " + RNGNumber);

        // IF the random number generated is less then or equal to the spawn chance
        if (RNGNumber <= PowerupSpawnChance)
        {
            // Initiate powerup spawning
            //Debug.Log("Spawning Powerup");

            // Generating a new random number between 0 and the length of the Powerupholder array
            RNGNumber = (int)Random.Range(0, 2);//powerupHolder.Length);
            
            // Spawn a powerup between the length of the powerup holder array
            // Destroys powerup after 7 seconds have passed
            switch(RNGNumber)
            {
                case 0:
                    // Instantiates the powerup
                    Debug.Log("Spawning Paddle Resize");
                    powerupClone = Instantiate(powerupHolder[0], this.transform.position, Quaternion.identity) as GameObject;
                    Destroy(powerupClone, 5.0f);
                    break;


                case 1:                    
                    Debug.Log("Spawning Fast Paddle");
                    powerupClone = Instantiate(powerupHolder[1], this.transform.position, Quaternion.identity) as GameObject;
                    Destroy(powerupClone, 5.0f);
                    break;


                case 2:
                    Debug.Log("Spawning Powershot");
                    break;


                case 3:
                    Debug.Log("Spawning Paddle Ascii");
                    break;


                case 4:
                    Debug.Log("Spawning Extra Pall");
                    break;
            }
        }

        if (col.gameObject.tag == "Ball")
        {
            // Disabled the brick for a period of time
		    Invoke("BrickToggle", brickDespawn);
	    	
		    // Respawns the brick after a period of time
		    Invoke("BrickToggle", brickRespawn); // Respawns the brick that was previously disabled
        }
	}
}