using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform = null;
	public float cameraDistanceFromPlayer = 20.0f;
	public float cameraHeightAbovePlayer = 6.0f;
	public float smoothCamera = 1.125f;

	// Start is called before the first frame update
	void Start()
    {
        
    }

	void LateUpdate()
	{
		if (playerTransform == null)
		{
			Debug.LogWarning("Player reference not set in CameraController");
			return;
		}

		Vector3 lerpPoint = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraHeightAbovePlayer, playerTransform.position.z - cameraDistanceFromPlayer);
		transform.position = Vector3.Lerp(this.transform.position, lerpPoint, smoothCamera * Time.deltaTime);
	}
}
