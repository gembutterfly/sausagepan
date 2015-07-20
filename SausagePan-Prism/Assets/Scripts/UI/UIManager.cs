using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private GameObject sound;
	private Inventory inventory;
	private UIBottomManager uIBottomManager;
	private AudioSource audioSource;

	public void Start() 
	{
		audioSource = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();

		if (!(Application.loadedLevelName.Equals ("Startbildschirm") || Application.loadedLevelName.Equals ("Credits"))) 
		{
			inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
			inventory.LoadInventory ();
		}

		if (  !( Application.loadedLevelName.Equals ("Rainbowgame") 
		      || Application.loadedLevelName.Equals ("Startbildschirm")
		      || Application.loadedLevelName.Equals ("Credits")
		      || Application.loadedLevelName.Equals ("LevelSelection")
		      || Application.loadedLevelName.Equals ("Quizze"))) 
		{
			uIBottomManager = GameObject.Find ("UIBottomManager").GetComponent<UIBottomManager> ();
			uIBottomManager.LoadColorList ();
		}

		sound = GameObject.Find ("Sound");
		int soundOn = PlayerPrefs.GetInt ("soundOn");
		
		if (soundOn == 1) {
			sound.SetActive (true);
			audioSource.volume = 1;
		} else {
			sound.SetActive (false);
			audioSource.volume = 0;
		}
	}

	public void Mute()
	{
		audioSource.volume = 0;
		sound.SetActive (false);
		PlayerPrefs.SetInt ("soundOn", 0);
	}

	public void Sound()
	{
		audioSource.volume = 1;
		sound.SetActive(true);
		PlayerPrefs.SetInt ("soundOn", 1);
	}

	public void QuitGame() {
		// Standalone-Player: Komplett schließen
		Application.Quit ();

		// Web-Player: Versuchen, geöffneten Tab zu schließen
		Application.ExternalEval ("open(location, '_self').close();");

		// Editor oder bei Fehlschlag der obigen Methoden:
		// Hauptbildschirm laden
		Application.LoadLevel ("Logoanimation");
	}

	public void RestartLevel() 
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
