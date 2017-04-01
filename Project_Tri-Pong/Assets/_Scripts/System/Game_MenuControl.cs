using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    //public Toggle CanBallIncreaseSpeedToggle;

    [Header("Brick Control Values")]
    // Reference to the brick controller
    public Brick_GroupController brickGroupController;

    public Brick_Controller[] Bricks;
    public float BrickRespawnTimer;     // How fast the brick will respawn
    public InputField BrickRespawnTimerIField;
    public float BrickTimerRateIncrease;     // Increases the rate of how fast the bricks will respawn every hit
    public InputField BrickTimerRateIncreaseInputField;
    public bool BrickCanIncreaseSpawnTime;   // Toggle to check if the bricks can increase its spawn time
    //public Toggle BrickCanIncreaseSpawnTimeToggle;
    public bool BricksCanRespawn;       // Toggle to check if the bricks can respawn after being hit
    //public Toggle BricksCanRespawnToggle;

    [Range(0, 100)]
    public int powerupSpawnChance;
    public Slider powerupSpawnChanceSlider;
    public Text powerupSpawnChanceText;

    [Header("Pause Menu Values")]
    public GameObject mainMenu;



    void Start()
    {
        // Game Initializaition
        //  SLider starts at what's defaut in the inspector
        powerupSpawnChanceSlider.value = powerupSpawnChance;
    }

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

            for (int i = 0; i < Bricks.Length; i++)
            {
                Bricks[i].brickRespawn = BrickRespawnTimer;
                Bricks[i].SpawnTimerRateIncrease = BrickTimerRateIncrease;
                Bricks[i].CanIncreaseSpawnTimer = BrickCanIncreaseSpawnTime;
                Bricks[i].BrickCanRespawn = BricksCanRespawn;
                Bricks[i].PowerupSpawnChance = powerupSpawnChance;
            }
            /*
            brickGroupController.brickRespawn = BrickRespawnTimer;
            brickGroupController.TimerRateIncrease = BrickTimerRateIncrease;
            brickGroupController.CanIncreaseSpawnTime = BrickCanIncreaseSpawnTime;
            brickGroupController.BricksCanRespawn = BricksCanRespawn;
            brickGroupController.PowerupSpawnChance = powerupSpawnChance;
            */
        }
        else if (!mainMenu.activeSelf)
        {
            //Unpauses game
            Time.timeScale = 1.0f;
        }
    }


    public void TogglePause()
    {
        // Toggles the main menu active
        //mainMenu.enabled = !mainMenu.enabled;
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void _RestartScene()
    {
        // Restarts the scene
        SceneManager.LoadScene("Tri-Pong Game");
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

    public void _BallSpeedRateCanIncrease(bool toggle)
    {
        // Changes the bool value of when if the ball speed can increase
        CanBallIncreaseSpeed = toggle;

    }


    /* Brick controllerN */

    public void _BrickRespawnTimer()
    {
        // Changes the brick respawn
        BrickRespawnTimer = float.Parse(BrickRespawnTimerIField.text);

        // Changes the text in the box
        //BrickRespawnTimerIField.text = BrickRespawnTimer.ToString();
    }

    public void _BrickTimerRateIncrease()
    {
        // Changes the brick timer rate 
        BrickTimerRateIncrease = float.Parse(BrickTimerRateIncreaseInputField.text);

        // Changes the box text
        BrickTimerRateIncreaseInputField.text = BrickTimerRateIncrease.ToString();
    }

    public void _BrickCanIncreaseSpawnTime(bool toggle)
    {
        // Changes the bool value to allow the bricks to increase the spawn time
        BrickCanIncreaseSpawnTime = toggle;
    }

    public void _BricksCanRespawn(bool toggle)
    {
        // Chanegs the bool value to allow the bricks to respawn
        BricksCanRespawn = toggle;
    }

    public void _PowerupSpawnChance()
    {
        //Slider adjusts spawn chance of powerups
        powerupSpawnChance = (int)powerupSpawnChanceSlider.value;

        // Changes the text of the Slider
        powerupSpawnChanceText.text = ("Powerup Spawn Chance: " + powerupSpawnChance.ToString() + "%");
    }
}
