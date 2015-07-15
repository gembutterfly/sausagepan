using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public void goToLevel(string level) {
		Application.LoadLevel (level);
		PlayerPrefs.SetInt ("lastLevelID", Application.loadedLevel); 
	}

	public void goBackToLastLevel() {
		Application.LoadLevel (PlayerPrefs.GetInt("lastLevelID"));
	}
}
