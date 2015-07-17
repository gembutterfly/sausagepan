using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public void goToLevel(string level) {
		if(level.Equals("Startbildschirm"))
		{	
			var go = GameObject.Find ("audio4");
			AudioSource help = go.GetComponent<AudioSource> ();
			help.Stop ();;
		}

		Application.LoadLevel (level);
		PlayerPrefs.SetInt ("lastLevelID", Application.loadedLevel); 
	}

	public void goBackToLastLevel() {
		Application.LoadLevel (PlayerPrefs.GetInt("lastLevelID"));
	}
}
