using UnityEngine;
using System.Collections;

public class GoToRainbowGame : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			Application.LoadLevel("Rainbowgame");
		}
	}
}
