using UnityEngine;
using System.Collections;

public class PlayerCam : MonoBehaviour {

	public Transform player;
	public float x = 3, y= 2, z = -1;

	private Transform cameraTransform;
	// Use this for initialization
	void Start () {
		cameraTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (player.position.x >= 454.0f) {
			cameraTransform.position = new Vector3(cameraTransform.position.x, player.position.y + y, z);
		}
		else
			cameraTransform.position = new Vector3 (player.position.x + x, player.position.y + y, z);
	
	}
}
