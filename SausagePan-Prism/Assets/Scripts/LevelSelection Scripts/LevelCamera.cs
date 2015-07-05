using UnityEngine;
using System.Collections;

public class LevelCamera : MonoBehaviour {

	private float z = -1;
	private Transform cameraTransform;

	public Transform playerTransform;
	public float x = 5, y = 5;

	// Use this for initialization
	void Start () {
		cameraTransform = GetComponent<Transform> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (playerTransform.position.x >= -12.0f) {

			if(playerTransform.position.y >= -17.0f)
			{
				cameraTransform.position = new Vector3 (cameraTransform.position.x, cameraTransform.position.y, z);
			}
			else
			{
				cameraTransform.position = new Vector3 (cameraTransform.position.x, playerTransform.position.y + y, z);
			}
		} 
		else 
		{
			if(playerTransform.position.y >= -17.0f)
			{
				cameraTransform.position = new Vector3 (playerTransform.position.x + x, cameraTransform.position.y, z);
			}
			else
			{
				cameraTransform.position = new Vector3 (playerTransform.position.x + x, playerTransform.position.y + y, z);
			}
		}
	
	}
}
