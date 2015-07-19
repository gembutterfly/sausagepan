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
		sound = GameObject.Find ("Sound");
		int soundOn = PlayerPrefs.GetInt ("soundOn");

		if (soundOn == 1) {
			sound.SetActive (true);
			audioSource.volume = 1;
		} else {
			sound.SetActive (false);
			audioSource.volume = 0;
		}

		if (  !( Application.loadedLevelName.Equals ("Startbildschirm") 
		      || Application.loadedLevelName.Equals ("Credits")
		      || Application.loadedLevelName.Equals ("intro")
		      || Application.loadedLevelName.Equals ("intro2")
		      || Application.loadedLevelName.Equals ("intro3")
		      || Application.loadedLevelName.Equals ("intro4")
		      || Application.loadedLevelName.Equals ("intro5")
		      || Application.loadedLevelName.Equals ("intro6")
		      || Application.loadedLevelName.Equals ("intro7")
		      || Application.loadedLevelName.Equals ("intro8")
		      || Application.loadedLevelName.Equals ("intro9")
		      || Application.loadedLevelName.Equals ("szene1")
		      || Application.loadedLevelName.Equals ("szene2")
		      || Application.loadedLevelName.Equals ("szene3")
		      || Application.loadedLevelName.Equals ("szene4")
		      || Application.loadedLevelName.Equals ("szene5")
		      || Application.loadedLevelName.Equals ("szene6")
		      || Application.loadedLevelName.Equals ("szene7")
		      || Application.loadedLevelName.Equals ("szene8")
		      || Application.loadedLevelName.Equals ("outro1")
		      || Application.loadedLevelName.Equals ("outro2")
		      || Application.loadedLevelName.Equals ("outro3")
		      || Application.loadedLevelName.Equals ("outro4")
		      || Application.loadedLevelName.Equals ("outro5")
		      || Application.loadedLevelName.Equals ("outro6")
		      || Application.loadedLevelName.Equals ("outro7")
		      || Application.loadedLevelName.Equals ("outro8")
		      || Application.loadedLevelName.Equals ("outro9")
		      || Application.loadedLevelName.Equals ("outro10")
		      || Application.loadedLevelName.Equals ("outro11")
		      || Application.loadedLevelName.Equals ("Quizze")))
			inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

		if (  !( Application.loadedLevelName.Equals ("Rainbowgame") 
		      || Application.loadedLevelName.Equals ("Startbildschirm")
		      || Application.loadedLevelName.Equals ("Credits")
		      || Application.loadedLevelName.Equals ("LevelSelection")
		      || Application.loadedLevelName.Equals ("intro")
		      || Application.loadedLevelName.Equals ("intro2")
		      || Application.loadedLevelName.Equals ("intro3")
		      || Application.loadedLevelName.Equals ("intro4")
		      || Application.loadedLevelName.Equals ("intro5")
		      || Application.loadedLevelName.Equals ("intro6")
		      || Application.loadedLevelName.Equals ("intro7")
		      || Application.loadedLevelName.Equals ("intro8")
		      || Application.loadedLevelName.Equals ("intro9")
		      || Application.loadedLevelName.Equals ("szene1")
		      || Application.loadedLevelName.Equals ("szene2")
		      || Application.loadedLevelName.Equals ("szene3")
		      || Application.loadedLevelName.Equals ("szene4")
		      || Application.loadedLevelName.Equals ("szene5")
		      || Application.loadedLevelName.Equals ("szene6")
		      || Application.loadedLevelName.Equals ("szene7")
		      || Application.loadedLevelName.Equals ("szene8")
		      || Application.loadedLevelName.Equals ("outro1")
		      || Application.loadedLevelName.Equals ("outro2")
		      || Application.loadedLevelName.Equals ("outro3")
		      || Application.loadedLevelName.Equals ("outro4")
		      || Application.loadedLevelName.Equals ("outro5")
		      || Application.loadedLevelName.Equals ("outro6")
		      || Application.loadedLevelName.Equals ("outro7")
		      || Application.loadedLevelName.Equals ("outro8")
		      || Application.loadedLevelName.Equals ("outro9")
		      || Application.loadedLevelName.Equals ("outro10")
		      || Application.loadedLevelName.Equals ("outro11")
		      || Application.loadedLevelName.Equals ("Quizze"))) 
		{
			uIBottomManager = GameObject.Find ("UIBottomManager").GetComponent<UIBottomManager> ();

			inventory.LoadInventory ();
			uIBottomManager.LoadColorList ();
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
