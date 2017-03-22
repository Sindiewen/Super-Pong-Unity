using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_PowerupController : MonoBehaviour 
{
	// Checks if paddle picked up any powerups
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "PaddleSizeIncrease")
		{
			// Adds the Paddle Size Increase Powerup
			PU_PaddleSizeIncrease PSI = this.gameObject.AddComponent<PU_PaddleSizeIncrease>();

			Destroy(PSI, 5.0f);
		}
	}

	// Returns the current name of the gameObject
	public string GetObjectName()
	{
		return this.gameObject.name;
	}

}
