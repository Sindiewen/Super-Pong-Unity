using UnityEngine;
public class Game_RNG
{
	float randomNumber; 		// Stores the random number

	Random rnd = new Random();	// Initializes the random number generator
	
	public float RNG()
	{
		// Run the RNG
		do
		{
			// Seeds random number
			randomNumber = Random.Range(-1, 1);
		}
		// As long as the seeded random number is not 0
		while (randomNumber == 0);

		// Returns the random number
		return randomNumber;
	}
}
