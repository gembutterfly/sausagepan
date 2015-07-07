using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int level = 0;

	private GameObject sound;

	public bool IsStartscreen = false;
	public float waitingTime = 1.0f;

	//spam für fade-in/fade-out zu Szenen
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;
	//spam ende

	public void loadNewLevel() {
		StartCoroutine("ChangeLevel");
	}

	public void endGame() {
		Application.Quit();
		Application.ExternalEval ("open(location, '_self').close();");
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
		sound.SetActive (true);
		PlayerPrefs.SetInt ("soundOn", 1);
	}

	//weiterer spam für fade-in/fade-out
	void OnGUI () {
	
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha); //wert zw. 0 und 1

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	//setzt fadeDir auf direction: -1 = fade-in; 1 = fade-out
	public float BeginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed);
	}

	void Start () 
	{
		BeginFade (-1);

		sound = GameObject.Find ("Sound");

		if (IsStartscreen)
			PlayerPrefs.SetInt ("soundOn", 1);

		if (Application.loadedLevel == 1)
			PlayerPrefs.DeleteAll ();
	}

	IEnumerator ChangeLevel () {
		float fadeTime = BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (level);
	}


	void Update () {
		if (IsStartscreen) 
			Invoke ("loadNewLevel", waitingTime);
	}
}
