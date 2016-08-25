using UnityEngine;
using System.Collections;

public class Brick_Controller : MonoBehaviour
{
	
	// Public Variables
	
	//public GameObject[] leftBrickHolder 	= GameObject.FindGameObjectsWithTag ("Left Brick");
	//public GameObject[] rightBrickHolder 	= GameObject.FindGameObjectsWithTag ("Right Brick");
	
	//public bool 	brickTimerSelect 	= false;	// Mode to turn on the mode to have bricks respawn mid-game after a set time
	public float 	brickRespawn		= 15f;


	// Private Variables --- DO NOT EDIt
	private MeshRenderer mesh;
	private BoxCollider2D box;

	
	void Start () 
	{

		mesh 	= GetComponent<MeshRenderer>();		// Ensures the mesh renderer is  on the gameobject
		box 	= GetComponent<BoxCollider2D>();	// Ensures the box collider is on the gameObject

	}
	
	void disableBrick()
	{
		mesh.enabled = !mesh.enabled;	// Diasbles the mesh renderer
		box.enabled = !box.enabled;		// Disables the box collider

		// DEPRICATED
		//gameObject.SetActive(false);	// Disables the brick attached to this script
	}
	
	void respawnBrick()
	{
		mesh.enabled = !mesh.enabled;	// Enables the mesh renderer
		box.enabled = !box.enabled;		// Enables the box collider

		// DEPRICATED
		//gameObject.SetActive(true); 	// Re-enables the bricks attached to this script
	}
	
	public void OnCollisionEnter2D(Collision2D col)	// When a ball collides to the brick...
	{
		
		disableBrick();	// Disables the collided brick	
		
		Invoke("respawnBrick", brickRespawn); //* Time.deltaTime);	// Respawns the brick that was previously disabled
	}
		
}