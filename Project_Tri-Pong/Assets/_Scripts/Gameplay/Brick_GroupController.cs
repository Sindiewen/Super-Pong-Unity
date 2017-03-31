using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_GroupController : MonoBehaviour
{

    // Public variables
    // Control the brick respawn time

    public Brick_Controller[] bricks;

    [Header ("Brick Respawn Values")]

    public float brickRespawn;          // The reate in which the bricks will respawn
    public float TimerRateIncrease;      // The rate in which the spawn rate will increase every hit
    public bool CanIncreaseSpawnTime;    // If the spawn rate can increase
    public bool BricksCanRespawn;        // If the bricks can respawn

    // Powerup Values
    [Header("Powerup Values")]

    [Range(0.0f, 100.0f)]
    public int PowerupSpawnChance = 50;    // The chance in which the bricks can spwan a powerup

    // Use this for initialization
    void Update()
    {
        // Initiate the brick values
        for (int i = 0; i < bricks.Length; i++)
        {
            // Set the brick values 
            bricks[i].brickRespawn = brickRespawn;
            bricks[i].SpawnTimerRateIncrease = TimerRateIncrease;
            bricks[i].CanIncreaseSpawnTimer = CanIncreaseSpawnTime;
            bricks[i].BrickCanRespawn = BricksCanRespawn;
        }
        
	}
	
}
