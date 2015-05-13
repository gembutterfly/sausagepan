using UnityEngine;
using System.Collections;

public class InkChar : MonoBehaviour {

	public string newColor = "black";
	private Color col = Color.black;
	private Color oldCol;

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
	}

	void OnTriggerEnter2D (Collider2D player) {
		Debug.Log (player.name + " entered ink area");

		if(player.name.Equals("blackBuddy")) {
			Debug.Log ("paint him " + newColor);
			paintChar(col);
		}
	}

	void paintChar(Color color) {
		GameObject bodypart = GameObject.Find ("blackBuddy/textures/head/head_side");
		SpriteRenderer sprite = bodypart.GetComponent<SpriteRenderer> ();

		// Get old color of figure
		oldCol = sprite.color;

		// determine mixed color
		color = mixColors (oldCol, color);

		sprite.color = color;
		
		bodypart = GameObject.Find ("blackBuddy/textures/body");
		sprite = bodypart.GetComponent<SpriteRenderer> ();
		sprite.color = color;
		
		bodypart = GameObject.Find ("blackBuddy/textures/foot_back");
		sprite = bodypart.GetComponent<SpriteRenderer> ();
		sprite.color = color;
		
		bodypart = GameObject.Find ("blackBuddy/textures/foot_front");
		sprite = bodypart.GetComponent<SpriteRenderer> ();
		sprite.color = color;
	}

	private Color mixColors(Color col1, Color col2) {
		Color mix = Color.black;

		// determine first color
		if (col1.Equals (Color.white) || col1.Equals (Color.black)) {
			mix = col2;
		}
		// he was blue
		if(col1.Equals (Color.blue)) {
			if(col2.Equals(Color.yellow)) {
				mix = Color.black;
			}
		}
		// he was green
		if(col1.Equals (Color.green)) {
			if(col2.Equals(Color.green)) {
				mix = Color.green;
			}
			if(col2.Equals(Color.magenta)) {
				mix = Color.black;
			}
		}

		// he was magenta
		if(col1.Equals (Color.magenta)) {
			if(col2.Equals(Color.green)) {
				mix = Color.black;
			}
			if(col2.Equals(Color.magenta)) {
				mix = Color.magenta;
			}
		}


		return mix;
	}
}
