using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_PowerupController : MonoBehaviour 
{
	// Checks if paddle picked up any powerups
	
	// private variables
	// Private Powerup References
	private bool PSIActive = false;		// PaddleSizeIncrease Variable
	


	void OnTriggerEnter2D(Collider2D col)
	{
		// Increase Paddle Size:
		// If collided, increase paddle size
		if(!PSIActive && col.gameObject.tag == "Paddle Size Increase")
		{
			// Power Up is active
			PSIActive = true;
			
			// Starts the coroutine of the paddle size increase
			StartCoroutine(_PaddleSizeIncrease(col));
		}
	}

	IEnumerator _PaddleSizeIncrease(Collider2D col)
	{
		// Destroys the collided gameObject
		Destroy(col.gameObject);
		
		// Increases the size of the paddle
		this.transform.localScale += new Vector3(0.0f, 2.5f, 0.0f);

		// Wait 5 seconds before reverting the paddles back to their previous state	
		yield return new WaitForSeconds(5.0f);

		// Returs the size of the paddle
		this.transform.localScale += new Vector3(0.0f, -2.5f, 0.0f);
		
		// The powerup is nolonger active
		PSIActive = false;
	}

}
