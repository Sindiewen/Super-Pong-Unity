using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game_MenuControl : MonoBehaviour
{
    // Public Variables
    // Allows control of values within the menu
    [Header("Paddle Control Values")]
    // Reference to the paddle controle object
    public Paddle_Controller paddleController;

    // Allows choice of either AI, 1 player or two players
    public int PlayersInGame;
    public InputField NumOfPlayersIField;      // Reference to the inputfield object

    public float paddleSpeed;           // How fast the paddles will move
    public InputField PaddleSpeedIField;

    public float powerupEffectStay;     // How long the powerups will stay on the paddles
    public InputField powerupEffectStayIField;


    [Header("Ball Control Values")]
    // Reference to the ball object
    public Ball_Controller ball;

    public float BallSpeed;             // How fast the ball will fly
    public InputField BallSpeedIField;
    public float MaxBallSpeed;          // the maximum ball speed
    public InputField MaxBallSpeedIField;
    public float BallSpeedRate;         // How much the speed of the ball will increase every hit
    public InputField BallSpeedRaceIncreaseIField;
    public bool CanBallIncreaseSpeed;   // Toggle to check if the ball can increase speed
    public Toggle CanBallIncreaseSpeedToggle;

    [Header("Brick Control Values")]
    // Reference to the brick controller
    public Brick_GroupController brickGroupController;

    public float BrickRespawnTimer;     // How fast the brick will respawn
    public float TimerRateIncrease;     // Increases the rate of how fast the bricks will respawn every hit
    public bool CanIncreaseSpawnTime;   // Toggle to check if the bricks can increase its spawn time
    public bool BricksCanRespawn;       // Toggle to check if the bricks can respawn after being hit

    [Range(0, 100)]
    public int powerupSpawnChance;

    [Header("Pause Menu Values")]
    public GameObject mainMenu;



    

    // Private Variables - Do Not Change or risk breaking everything
    //private bool isPaused = true;   // Game Starts paused - Checks if game is paused or not
    // Update Function //
    private void Update()
    {
        // If the user hits the escape key, they toggle pause
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            // toggles pause
            TogglePause();
        }

        // If the main menu is currently active
        if (mainMenu.activeSelf)
        {
            // pauses game
            Time.timeScale = 0.0f;

            // Dynamically change each of the values of the menu
            // Change paddlecontroller values
            paddleController.PlayersInGame = PlayersInGame;
            paddleController.paddleSpeed = paddleSpeed;
            paddleController.PowerupEffectStay = powerupEffectStay;

            // CHange Ball Values
            ball.ballSpeed = BallSpeed;
            ball.maxBallSpeed = MaxBallSpeed;
            ball.ballSpeedRate = BallSpeedRate;
            ball.ballSpeedIncrease = CanBallIncreaseSpeed;

            // Change brick values
            brickGroupController.brickRespawn = BrickRespawnTimer;
            brickGroupController.TimerRateIncrease = TimerRateIncrease;
            brickGroupController.CanIncreaseSpawnTime = CanIncreaseSpawnTime;
            brickGroupController.BricksCanRespawn = BricksCanRespawn;
            brickGroupController.PowerupSpawnChance = powerupSpawnChance;
        }
        else if (!mainMenu.activeSelf)
        {
            //Unpauses game
            Time.timeScale = 1.0f;
        }
    }


    private void TogglePause()
    {
        // Toggles the main menu active
        //mainMenu.enabled = !mainMenu.enabled;
        mainMenu.SetActive(!mainMenu.activeSelf);
    }





    // UI Values

    // Changes the players in game

        /* Paddle Controller */

    public void _NumberOfPlayers()
    {
        // Stores the value from the inputfield into the variable
        PlayersInGame = Convert.ToInt32(NumOfPlayersIField.text);
        
        // Changes the ifield to show the new value
        NumOfPlayersIField.text = PlayersInGame.ToString();
    }

    public void _PaddleSpeed()
    {
        // Stores the new paddle speed from input field into the variable
        paddleSpeed = float.Parse(PaddleSpeedIField.text);

        // Changes the ifield to show the new value
        PaddleSpeedIField.text = paddleSpeed.ToString();

    }

    public void _PowerupEffectTime()
    {
        // Stores new powerup effect time
        powerupEffectStay = float.Parse(powerupEffectStayIField.text);

        // Changes field to new value
        powerupEffectStayIField.text = powerupEffectStay.ToString();
    }


    /* Ball Object */

    public void _BallSpeed()
    {
        // Changes ball speed
        BallSpeed = float.Parse(BallSpeedIField.text);

        // Shows text change
        BallSpeedIField.text = BallSpeed.ToString();
    }

    public void _BallSpeedMax()
    {
        // Changes Max Ball Speed
        MaxBallSpeed = float.Parse(MaxBallSpeedIField.text);

        // Shows text change
        MaxBallSpeedIField.text = MaxBallSpeed.ToString();
    }

    public void _BallSpeedRateIncrease()
    {
        // Changes the rate the ball speed increases
        BallSpeedRate = float.Parse(BallSpeedRaceIncreaseIField.text);

        // Changes the text
        BallSpeedRaceIncreaseIField.text = BallSpeedRate.ToString();
    }

    public void _BallSpeedRateCanIncrease(bool value)
    {
        // Changes the bool value of when if the ball speed can increase
        CanBallIncreaseSpeed = value;

    }
}
