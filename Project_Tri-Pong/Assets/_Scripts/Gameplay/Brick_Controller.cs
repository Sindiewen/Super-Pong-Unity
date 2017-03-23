using UnityEngine;
using System.Collections;

public class Brick_Controller : MonoBehaviour
{
	
	// Public Variables
	public float 	brickRespawn		= 15f; 	// Brick respawn timer


	// Private Variables --- DO NOT EDIt
	private SpriteRenderer sprite;			// Reference to the SpriteRenderer
	private BoxCollider2D box;				// Reference to the box collider

	private float brickDespawn = 0.02f;		// Brick despawn timer

	
	void Start () 
	{
		sprite	= GetComponent<SpriteRenderer>();	// Reference to the SpriteRenderer
		box 	= GetComponent<BoxCollider2D>();	// Ensures the box collider is on the gameObject
	}
	
	void BrickToggle()
	{
		//mesh.enabled = !mesh.enabled;	// Enables the mesh renderer
		sprite.enabled = !sprite.enabled;
		box.enabled = !box.enabled;		// Enables the box collider
	}
	
	void OnCollisionEnter2D(Collision2D col)	// When a ball collides to the brick...
	{
		// Disabled the brick for a period of time
		Invoke("BrickToggle", brickDespawn);
		
		// Respawns the brick after a period of time
		Invoke("BrickToggle", brickRespawn); // Respawns the brick that was previously disabled
	}
		
}