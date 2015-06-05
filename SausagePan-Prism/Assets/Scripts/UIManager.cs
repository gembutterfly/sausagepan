using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	public Image sound;

	void Start()
	{	
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

	public void QuitGame() {
		Application.Quit ();
	}
}
