using UnityEngine;
using System.Collections;

/** Don't forget to add a collider
 * */

public class SwitchOnLamps : MonoBehaviour {

	public SpriteRenderer lightCone;
	public string color;
	private Color col;
	private bool lampSwitch = false;

	// Use this for initialization
	void Start () {
		switch (this.color) {
		case "blue": col = Color.blue;break;
		case "red": col = Color.red;break;
		case "green": col = Color.green;break;
		default: col = Color.white;break;
		}
		col.a = 0;
		lightCone.color = col;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		if (!lampSwitch) {
			col.a = 1;
			lampSwitch = true;
		} else {
			col.a = 0;
			lampSwitch = false;
		}
		
		lightCone.color = col;
	}
}
