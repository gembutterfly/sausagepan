using UnityEngine;
using System.Collections;

public class InkChar : MonoBehaviour {

	public string newColor = "black";
	private Color col = Color.black;
	private Color oldCol;
	private PlayerController playerController;

	void Start() {
		switch (newColor) {
		case "blue": col = Color.blue; break;
		case "red": col = Color.red; break;
		case "white": col = Color.white; break;
		case "yellow": col = Color.yellow; break;
		case "green": col = Color.green; break;
		case "magenta": col = Color.magenta; break;
		default: col = Color.black; break;
		}
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
	}

	void OnTriggerEnter2D (Collider2D player) {
//		Debug.Log (player.name + " entered ink area");

		if(player.name.Equals("blackBuddy")) {
			Debug.Log ("paint him " + newColor);
			playerController.PaintChar(col, false);
		}
	}

}
