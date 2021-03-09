using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This enum defines all possible game states
/// The game starts at Idle by default, which represents the main menu
/// When the player clicks Play in main menu, the gamestate changes to Active
/// PlayerBehaviour also uses this to prevent the player object from moving when it's not needed
/// </summary>
public enum GameState
{
	Idle,
	Active,
	PostGameWin,
	PostGameLose
}

public class GameController : MonoBehaviour
{
	public static GameController GameControllerInstance;    // singleton, accessible anywhere in the code

	[HideInInspector]
	public GameState gameState = GameState.Idle;

	void Start()
	{
		// Assigns GameControllerInstance to 'this' in case its not initialized
		if (GameControllerInstance == null)
		{
			GameControllerInstance = this;
		}
	}
}
