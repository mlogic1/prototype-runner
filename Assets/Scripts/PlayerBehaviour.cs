using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
	public float playerRunningSpeed = 40.0f;
	public float playerLaneSwitchSpeed = 5.0f;
	private int playerLaneIndex = 1;
	public List<Transform> runningLanes;

	public Transform WinScreen;
	public Transform LoseScreen;
	private Rigidbody playerRigidBody = null;

	private float laneSwitchCooldown = 0.0f;
	private const float LANE_SWITCH_COOLDOWN_INCREMENT = 0.3f;
	
	/// <summary>
	/// This function detects when player collides with an object that is marked as IsTrigger. Its used to show win or lose screens
	/// </summary>
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("DeathFloor"))
		{
			ShowLoseScreen();
		}
		else if (other.tag.Equals("Finish"))
		{
			ShowWinScreen();
		}
	}

	/// <summary>
	/// Enables lose screen object
	/// </summary>
	private void ShowLoseScreen()
	{
		GameController.GameControllerInstance.gameState = GameState.PostGameLose;
		LoseScreen.gameObject.SetActive(true);
	}

	/// <summary>
	/// Enables win screen object
	/// </summary>
	private void ShowWinScreen()
	{
		GameController.GameControllerInstance.gameState = GameState.PostGameWin;
		WinScreen.gameObject.SetActive(true);
	}

	void Start()
	{
		playerRigidBody = GetComponent<Rigidbody>();	// setup reference to player Rigidbody physics behaviour

		if (runningLanes.Count != 3)	// error should be logged if running lanes aren't setup properly
		{
			Debug.LogError("Lanes not setup properly");
		}
	}

	void Update()
	{
		// Player shouldnt start running until gamestate is set to active (when you are looking at main menu or win/lose screens)
		if (!GameController.GameControllerInstance.gameState.Equals(GameState.Active))
		{
			return;
		}

		if (playerRigidBody == null) // error checking
		{
			Debug.LogWarning("RigidBody component not found on PlayerBehaviour");
			return;
		}

		// lane switch cooldown prevents the player from switching lanes too fast
		laneSwitchCooldown -= Time.deltaTime;
		if (laneSwitchCooldown < 0.0f)
		{
			laneSwitchCooldown = 0.0f;
		}

		// keyboard input, switches player lanes to the left
		if (Input.GetKeyDown(KeyCode.A) && laneSwitchCooldown < 0.01f)
		{
			playerLaneIndex--;
			if (playerLaneIndex < 0)
			{
				playerLaneIndex = 0;
				IncreaseCooldown();
			}
		}

		// keyboard input, switches player lanes to the right
		if (Input.GetKeyDown(KeyCode.D) && laneSwitchCooldown < 0.01f)
		{
			playerLaneIndex++;
			if (playerLaneIndex > 2)
			{
				playerLaneIndex = 2;
			}
			IncreaseCooldown();
		}

		// check current player lane
		Transform targetLane = runningLanes[playerLaneIndex];
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetLane.position.x, playerLaneSwitchSpeed * Time.deltaTime), transform.position.y, transform.position.z);    // lerp left and right
		transform.position += transform.forward * playerRunningSpeed * Time.deltaTime;  // move forward
	}

	/// <summary>
	/// Prevents player from moving left and right too often
	/// </summary>
	private void IncreaseCooldown()
	{
		laneSwitchCooldown += LANE_SWITCH_COOLDOWN_INCREMENT;
	}
}
