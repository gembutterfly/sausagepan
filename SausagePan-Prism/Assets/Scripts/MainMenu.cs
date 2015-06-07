using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int level = 0;
	
	public void loadNewLevel() {
		Application.LoadLevel (level);
	}

	public void endGame() {
		Application.Quit();
	}

	public void Update() {
//		if (AudioSource.mute) {
//
//		}

	}
}
