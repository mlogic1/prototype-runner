using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float playerJumpStrenght = 200.0f;
    public float playerRunningSpeed = 20.0f;
    private Rigidbody playerRigidBody = null;

    public float playerLaneSwitchSpeed = 10.0f;
    private int playerLaneIndex = 1;
    public List<Transform> runningLanes;
    
    public float laneSwitchCooldown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        if (runningLanes.Count != 3)
		{
            Debug.LogError("Lanes not sorted properly");
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidBody == null)
		{
            Debug.LogWarning("RigidBody component not found on PlayerBehaviour");
            return;
		}

        if (Input.GetKey(KeyCode.Space))
		{
            playerRigidBody.AddForce(new Vector3(0.0f, playerJumpStrenght), ForceMode.Impulse);
		}

        laneSwitchCooldown -= Time.deltaTime;
        if (laneSwitchCooldown < 0.0f)
        {
            laneSwitchCooldown = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.A) && laneSwitchCooldown < 0.1f)
		{
            playerLaneIndex--;
            laneSwitchCooldown += 0.35f;
            if (playerLaneIndex < 0)
			{
                playerLaneIndex = 0;
			}
		}

        if (Input.GetKeyDown(KeyCode.D) && laneSwitchCooldown < 0.1f)
        {
            playerLaneIndex++;
            laneSwitchCooldown += 0.35f;
            if (playerLaneIndex > 2)
            {
                playerLaneIndex = 2;
			}
        }


        Transform targetLane = runningLanes[playerLaneIndex];
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetLane.position.x, playerLaneSwitchSpeed * Time.deltaTime), transform.position.y, transform.position.z);    // lerp left and right
        transform.position += transform.forward * playerRunningSpeed * Time.deltaTime;  // move forward
    }
}
