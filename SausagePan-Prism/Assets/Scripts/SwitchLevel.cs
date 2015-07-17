using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	private UIManager uIManager;
	private string levelName;

	public void goToLevel(string level) {
		if(level.Equals("Startbildschirm") && Application.loadedLevel != 16 && Application.loadedLevel != 25)
		{	
			var go = GameObject.Find ("audio4");
			AudioSource help = go.GetComponent<AudioSource> ();
			help.Stop ();
		}

		levelName = level;
		StartCoroutine ("ChangeLevel");
	}

	public void goBackToLastLevel() {
		Application.LoadLevel (PlayerPrefs.GetInt("lastLevelID"));
	}

	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("UIManager").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);

		Application.LoadLevel (levelName);
		PlayerPrefs.SetInt ("lastLevelID", Application.loadedLevel); 
	}
}
