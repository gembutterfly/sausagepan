using UnityEngine;
using System.Collections;

public class PlattformScript : MonoBehaviour {

	public float newSpeed;
	public float oldSpeed;

	PlayerController playerController;

	public void OnTriggerEnter2D (Collider2D other)
	{
		playerController.maxSpeed = newSpeed;
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		playerController.maxSpeed = newSpeed;
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		playerController.maxSpeed = oldSpeed;
	}
	
	void Start()
	{
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		oldSpeed = playerController.maxSpeed;
	}
}
