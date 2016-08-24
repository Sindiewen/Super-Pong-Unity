using UnityEngine;
using System.Collections;

public class Brick_Controller : MonoBehaviour
{
	
	// Public Variables
	
	//public GameObject[] leftBrickHolder 	= GameObject.FindGameObjectsWithTag ("Left Brick");
	//public GameObject[] rightBrickHolder 	= GameObject.FindGameObjectsWithTag ("Right Brick");
	
	public bool 	brickTimerSelect 	= false;	// Mode to turn on the mode to have bricks respawn mid-game after a set time
	//public float 	brickTimerSeconds	= 500;		// Brick respawn timer
	public float 	brickRespawn		= 5f;


	// Private Variables --- DO NOT EDIT
	//private float brickTimerCountdown;

	private MeshRenderer mesh;
	private BoxCollider2D box;

	
	void Start () 
	{

		mesh 	= GetComponent<MeshRenderer>();
		box 	= GetComponent<BoxCollider2D>();

		// if (brickTimerSelect == false)
		// {
		// 	return;
		// }
		
		// if (brickTimerSelect == true)
		// {
		// 	respawnBrick();
		// }

		//brickTimerSelect = false;	// Ensures at gamestart, the bricks will not respawn
		
	//	respawnBrick();				// Ensures the bricks are enables at the start of the scene
	}
	
	void disableBrick()
	{
		mesh.enabled = !mesh.enabled;
		box.enabled = !box.enabled;
		//gameObject.SetActive(false);	// Disables the brick attached to this script
	}
	
	void respawnBrick()
	{
		mesh.enabled = !mesh.enabled;
		box.enabled = !box.enabled;
		//gameObject.SetActive(true); 	// Re-enables the bricks attached to this script
	}
	
	public void OnCollisionEnter2D(Collision2D col)	// When a ball collides to the brick...
	{
		
		disableBrick();	// Disables the collided brick	
	
		
		if (brickTimerSelect == true)	// if true...
		{
			Invoke("respawnBrick", brickRespawn);
			//brickTimerRespawn();		// Calls the brick timer respawn function
		}
		
	}
	
	public void brickTimerRespawn()
	{

		Invoke("respawnBrick", brickRespawn);

//		brickTimerCountdown = brickTimerSeconds;	// Sets the timer countdown to = the seconds the countdown will be
//		
//		brickTimerCountdown -= Time.deltaTime;
//		
//		while (brickTimerCountdown > 0)
//		{
//			brickTimerCountdown--;
//		}
//		
//		if (brickTimerCountdown <= 0)	// if countdown < 0...
//		{
//			gameObject.SetActive(true);	// Sets the gameobject to true
//		}
//		
	}
}