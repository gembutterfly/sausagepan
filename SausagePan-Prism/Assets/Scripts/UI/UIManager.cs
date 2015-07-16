using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private GameObject sound;
	private Inventory inventory;
	private UIBottomManager uIBottomManager;

	public void Start() 
	{
		sound = GameObject.Find ("Sound");
//		sound.SetActive (false);
		this.gameObject.AddComponent<GlobalSound>();

		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

		if (!(Application.loadedLevelName.Equals ("Rainbowgame") || Application.loadedLevelName.Equals ("LevelSelection"))) 
		{
			uIBottomManager = GameObject.Find ("UIBottomManager").GetComponent<UIBottomManager> ();

			inventory.LoadInventory ();
			uIBottomManager.LoadColorList ();
		}
	}

	public void Mute()
	{
		AudioListener.volume = 0;
		sound.SetActive (false);
		PlayerPrefs.SetInt ("soundOn", 0);
	}

	public void Sound()
	{
		AudioListener.volume = 1;
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
