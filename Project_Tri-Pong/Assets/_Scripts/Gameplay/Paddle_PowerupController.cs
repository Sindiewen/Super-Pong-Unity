//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Paddle_PowerupController : MonoBehaviour 
{
	// Checks if paddle picked up any powerups

	void Start()
	{
		PU_PaddleSizeIncrease PSI = this.gameObject.AddComponent<PU_PaddleSizeIncrease>() as PU_PaddleSizeIncrease;

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Paddle Size Increase")
		{
			// Adds the Paddle Size Increase Powerup
			Debug.Log("Adding AddComponent");
			PU_PaddleSizeIncrease PSI = this.gameObject.AddComponent<PU_PaddleSizeIncrease>() as PU_PaddleSizeIncrease;

			//Destroy(PSI, 100.0f);
		}
	}

	// Returns the current name of the gameObject
	public string GetObjectName()
	{
		return this.gameObject.name;
	}

}
