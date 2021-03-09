using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float playerJumpStrenght = 200.0f;
    public float playerRunningSpeed = 20.0f;
    private Rigidbody playerRigidBody = null;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.forward * playerRunningSpeed * Time.deltaTime;


        if (playerRigidBody == null)
		{
            Debug.LogWarning("RigidBody component not found on PlayerBehaviour");
            return;
		}

        if (Input.GetKey(KeyCode.Space))
		{
            playerRigidBody.AddForce(new Vector3(0.0f, playerJumpStrenght), ForceMode.Impulse);
		}
    }
}
