using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_PaddleSizeIncrease : Paddle_PowerupController
{
	// Increases the size of the paddle when the paddle collects the powerup
	// Private Variables
	private Paddle_PowerupController powerCont;	// Stores reference to the Paddle_PowerupController
	
	// Use this for initialization
	void Start () 
	{
		// Gets the Paddle_PowerupController
		powerCont = GetComponent<Paddle_PowerupController>();
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("Increase Paddle Size on paddle " + powerCont.GetObjectName());	
	}
}
