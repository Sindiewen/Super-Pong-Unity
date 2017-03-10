using System;
using System.Collections.Generic;

public class Paddle_Controller_Catalog
{
	// Public Class Variables

	// Public Enum of Players
	public enum _PlayersInGame : int
	{
		AIOnly 			= 0,		// No players	- AI Playing itself only
		SinglePlayer 	= 1,		// 1 Player 	- Human VS AI
		TwoPlayers 		= 2,		// 2 Players	- Human VS Human
		SixPlayers		= 6,		// 6 Players	- 3 VS 3 (1 Player Per Paddle)
	};
}