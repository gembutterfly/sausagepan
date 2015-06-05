using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int level = 0;
	public Image sound;

	public void loadNewLevel() {
		Application.LoadLevel (level);
	}

	public void endGame() {
		Application.Quit();
		Application.ExternalEval ("window.close();");
	}

	public void Mute()
	{
		AudioListener.volume = 0;
		sound.enabled = false;
	}
	
	public void Sound()
	{
		AudioListener.volume = 1;
		sound.enabled = true;
	}
}
