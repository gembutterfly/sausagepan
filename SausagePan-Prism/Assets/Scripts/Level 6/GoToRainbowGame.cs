using UnityEngine;
using System.Collections;

public class GoToRainbowGame : MonoBehaviour {

	private Gate gate;
	private PlayerController playerController;

	// Use this for initialization
	void Start () 
	{
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		gate = GameObject.Find ("Gate").transform.GetChild (0).GetComponent<Gate> ();
	}
	
	void LoadNewLevel()
	{
		gate.NewLevel ();
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Invoke ("LoadNewLevel", 2);

			playerController.enabled = false;
		}
	}
}
