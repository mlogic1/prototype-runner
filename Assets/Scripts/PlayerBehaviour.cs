using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    private const float LANE_SWITCH_COOLDOWN_INCREMENT = 0.3f;

    public float playerJumpStrength;
    public float playerRunningSpeed = 20.0f;
    private Rigidbody playerRigidBody = null;

    public float playerLaneSwitchSpeed = 10.0f;
    private int playerLaneIndex = 1;
    public List<Transform> runningLanes;

    public Transform WinScreen;
    public Transform LoseScreen;

    private float laneSwitchCooldown = 0.0f;

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

    private void ShowLoseScreen()
    {
        GameController.GameControllerInstance.gameState = GameState.PostGameLose;
        LoseScreen.gameObject.SetActive(true);
    }

    private void ShowWinScreen()
    {
        GameController.GameControllerInstance.gameState = GameState.PostGameWin;
        WinScreen.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        if (runningLanes.Count != 3)
        {
            Debug.LogError("Lanes not setup properly");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.GameControllerInstance.gameState.Equals(GameState.Active))
        {
            return;
        }

        if (playerRigidBody == null)
        {
            Debug.LogWarning("RigidBody component not found on PlayerBehaviour");
            return;
        }

        laneSwitchCooldown -= Time.deltaTime;
        if (laneSwitchCooldown < 0.0f)
        {
            laneSwitchCooldown = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.A) && laneSwitchCooldown < 0.01f)
        {
            playerLaneIndex--;
            if (playerLaneIndex < 0)
            {
                playerLaneIndex = 0;
                IncreaseCooldown();
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && laneSwitchCooldown < 0.01f)
        {
            playerLaneIndex++;
            if (playerLaneIndex > 2)
            {
                playerLaneIndex = 2;
            }
            IncreaseCooldown();
        }

        Transform targetLane = runningLanes[playerLaneIndex];
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetLane.position.x, playerLaneSwitchSpeed * Time.deltaTime), transform.position.y, transform.position.z);    // lerp left and right
        transform.position += transform.forward * playerRunningSpeed * Time.deltaTime;  // move forward
    }

    private void IncreaseCooldown()
	{
        laneSwitchCooldown += LANE_SWITCH_COOLDOWN_INCREMENT;
    }
}
