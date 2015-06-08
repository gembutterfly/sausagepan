using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public void goToLevel(string level) {
		Application.LoadLevel (level);
	}
}
