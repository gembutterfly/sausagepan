using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject blackCloud;
	public GameObject whiteCloud;

	GameObject sound;
	GameObject player;
	bool blackCloudIsActive = false;
	bool whiteCloudIsActive = false;

	public void Start() {
		sound = GameObject.Find ("Sound");
		this.gameObject.AddComponent<GlobalSound>();

		player = GameObject.FindGameObjectWithTag("Player");
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
		Application.LoadLevel ("Startbildschirm");
	}

	public void RestartLevel() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void CallBlackCloud()
	{
		if (!blackCloudIsActive) 
		{
			blackCloudIsActive = true;

			blackCloud.SetActive (true);
			blackCloud.GetComponent<Transform> ().localPosition = new Vector3 (player.GetComponent<Transform> ().localPosition.x,
		                                                                 	   player.GetComponent<Transform> ().localPosition.y + 5,
		                                                                  	   player.GetComponent<Transform> ().localPosition.z);
			Invoke ("ResetBlackCloud", 5);
		}
	}

	public void CallWhiteCloud()
	{
		if (!whiteCloudIsActive) 
		{
			whiteCloudIsActive = true;

			whiteCloud.SetActive (true);
			whiteCloud.GetComponent<Transform> ().localPosition = new Vector3 (player.GetComponent<Transform> ().localPosition.x,
		                                                                   	   player.GetComponent<Transform> ().localPosition.y + 5,
		                                                                   	   player.GetComponent<Transform> ().localPosition.z);
			Invoke ("ResetWhiteCloud", 5);
		}
	}

	void ResetBlackCloud()
	{
		blackCloud.SetActive (false);
		blackCloudIsActive = false;
	}

	void ResetWhiteCloud()
	{
		whiteCloud.SetActive (false);
		whiteCloudIsActive = false;
	}
}
