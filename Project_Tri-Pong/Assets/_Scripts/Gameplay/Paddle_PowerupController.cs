using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_PowerupController : MonoBehaviour 
{
	// Checks if paddle picked up any powerups

	// Public variables
	
	// Hidden Values from the Inspector - Is used in a different script
	

	[HideInInspector]						// Note, edit PowerupEffectStay in Paddle_Controller.cs
	public float PowerupEffectStay = 5.0f;	// How long the powerup should last on the paddle


	[HideInInspector]					// Note, edit paddle speed through Paddle_Controller.cs
	public float paddleSpeed = 3.0f;	// Stores the current paddle speed

    // Holds the powerup Particle Objects
    public GameObject[] PowerupParticles;
										
										
	// Private Variables
	private bool PSIActive = false;		// PaddleSizeIncrease Variable
	private bool PSpeedActive = false;  // Paddle Speec Increase

    // Runs at the start of the game
    private void Start()
    {
        // Sets the speed partcile to off
        for (int i = 0; i < PowerupParticles.Length; i++)
        {
            // Sets all the powerup particles to off
            PowerupParticles[i].SetActive(false);
           
        }

  
    }

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

		// increase paddle speed:
		// If collided, increase paddle speed
		if (!PSpeedActive && col.gameObject.tag == "Paddle Speed Increase")
		{
			// Powerup is active
			PSpeedActive = true;

			// Starts the coroutine of the paddle speed increase
			StartCoroutine(_PaddleSpeedIncrease(col));
		}
	}

	IEnumerator _PaddleSizeIncrease(Collider2D col)
	{
		// Destroys the collided gameObject
		Destroy(col.gameObject);
		
		// Increases the size of the paddle
		this.transform.localScale += new Vector3(0.0f, 2f, 0.0f);

        // Enables the size increase particle
        PowerupParticles[0].SetActive(true);

		// Wait 5 seconds before reverting the paddles back to their previous state	
		yield return new WaitForSeconds(PowerupEffectStay);

		// Returs the size of the paddle
		this.transform.localScale += new Vector3(0.0f, -2f, 0.0f);

        // Disables the size increase particle
        PowerupParticles[0].SetActive(false);
		
		// The powerup is nolonger active
		PSIActive = false;
	}

	IEnumerator _PaddleSpeedIncrease(Collider2D col)
	{
		// Destroys the collided gameObject
		Destroy(col.gameObject);

		// Increase the speed of the paddle by 2
		paddleSpeed *= 2;

        // Enables the speed particle
        PowerupParticles[1].SetActive(true);

		// Wait 5 seconds before returning the paddles back to their previous speed
		yield return new WaitForSeconds(PowerupEffectStay);

		// Returns the speed of the paddle
		paddleSpeed /= 2;

        // Disables the speed particle
        PowerupParticles[1].SetActive(true);

		// The powerup is nolonger active
		PSpeedActive = false;
	}

}
