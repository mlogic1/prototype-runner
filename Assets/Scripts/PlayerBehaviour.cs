using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody playerRigidBody = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidBody == null)
		{
            return;
		}

        if (Input.GetKey(KeyCode.W))
		{

		}
    }
}
