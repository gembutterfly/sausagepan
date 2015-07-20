using UnityEngine;
using System.Collections;

public class audio_intro : MonoBehaviour {

	public GameObject canvas;

	private AudioSource audioSource;
	private AudioSource secondAudioSource;
	private GameObject sound;

	// Use this for initialization
	void Start () 
	{
		audioSource = GameObject.Find ("audio").GetComponent<AudioSource> ();
		sound = GameObject.Find ("Sound");

		int soundOn = PlayerPrefs.GetInt ("soundOn");
		
		if (soundOn == 1) {
			sound.SetActive (true);
			SoundONSelection ();
		} else {
			sound.SetActive (false);
			SoundOFFSelection ();
		}


		DontDestroyOnLoad (this.gameObject);
	}

	public void Mute()
	{
		SoundOFFSelection ();
		sound.SetActive (false);
		PlayerPrefs.SetInt ("soundOn", 0);
	}
	
	public void Sound()
	{
		SoundONSelection ();
		sound.SetActive(true);
		PlayerPrefs.SetInt ("soundOn", 1);
	}

	public void Skip()
	{
		SoundEXITSelection ();
		StartCoroutine ("ChangeLevel");
	}

	
	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);

		if (Application.loadedLevelName.Equals ("szene1")
			|| Application.loadedLevelName.Equals ("szene2")
			|| Application.loadedLevelName.Equals ("szene3")
			|| Application.loadedLevelName.Equals ("szene4")) {
			Application.LoadLevel ("LevelSelection");
		}

		if (Application.loadedLevelName.Equals ("szene5")
			|| Application.loadedLevelName.Equals ("szene6")
			|| Application.loadedLevelName.Equals ("szene7")
			|| Application.loadedLevelName.Equals ("szene8")) {
			Application.LoadLevel ("Level6");
		}

		if (Application.loadedLevelName.Equals ("outro1")
			|| Application.loadedLevelName.Equals ("outro2")
			|| Application.loadedLevelName.Equals ("outro3")
			|| Application.loadedLevelName.Equals ("outro4")
			|| Application.loadedLevelName.Equals ("outro5")
			|| Application.loadedLevelName.Equals ("outro6")
			|| Application.loadedLevelName.Equals ("outro7")
			|| Application.loadedLevelName.Equals ("outro8")
			|| Application.loadedLevelName.Equals ("outro9")
			|| Application.loadedLevelName.Equals ("outro10")
			|| Application.loadedLevelName.Equals ("outro11")) {
			Application.LoadLevel ("Credits");
		} 

		if (Application.loadedLevelName.Equals ("intro")
		    || Application.loadedLevelName.Equals ("intro2")
		    || Application.loadedLevelName.Equals ("intro3")
		    || Application.loadedLevelName.Equals ("intro4")
		    || Application.loadedLevelName.Equals ("intro5")
		    || Application.loadedLevelName.Equals ("intro6")
		    || Application.loadedLevelName.Equals ("intro7")
		    || Application.loadedLevelName.Equals ("intro8")
		    || Application.loadedLevelName.Equals ("intro9")){
			Application.LoadLevel ("Level1");
		}
			
		Destroy (canvas);
		Destroy (this.gameObject);
	}

	void SoundONSelection()
	{
		if (Application.loadedLevelName.Equals ("intro2") || Application.loadedLevelName.Equals ("intro3"))
			secondAudioSource = GameObject.Find("GameObject").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro4")) 
			secondAudioSource = GameObject.Find("moth_push").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro6"))
			secondAudioSource = GameObject.Find("explosion_sky").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro7"))
			secondAudioSource = GameObject.Find("explosion_full").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro9"))
			secondAudioSource = GameObject.Find("mothcounciessness").GetComponent<AudioSource>();

		audioSource.volume = 1;

		if ( (   Application.loadedLevelName.Equals ("intro2") 
		      || Application.loadedLevelName.Equals ("intro3") 
		      || Application.loadedLevelName.Equals ("intro4")
		      || Application.loadedLevelName.Equals ("intro6")
		      || Application.loadedLevelName.Equals ("intro7")
		      || Application.loadedLevelName.Equals ("intro9")))
			secondAudioSource.volume = 1;
	}

	void SoundOFFSelection()
	{
		if (Application.loadedLevelName.Equals ("intro2") || Application.loadedLevelName.Equals ("intro3"))
			secondAudioSource = GameObject.Find("GameObject").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro4")) 
			secondAudioSource = GameObject.Find("moth_push").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro6"))
			secondAudioSource = GameObject.Find("explosion_sky").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro7"))
			secondAudioSource = GameObject.Find("explosion_full").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro9"))
			secondAudioSource = GameObject.Find("mothcounciessness").GetComponent<AudioSource>();

		audioSource.volume = 0;

		if ( (   Application.loadedLevelName.Equals ("intro2") 
		      || Application.loadedLevelName.Equals ("intro3") 
		      || Application.loadedLevelName.Equals ("intro4")
		      || Application.loadedLevelName.Equals ("intro6")
		      || Application.loadedLevelName.Equals ("intro7")
		      || Application.loadedLevelName.Equals ("intro9")))
			secondAudioSource.volume = 0;
	}

	void SoundEXITSelection()
	{
		if (Application.loadedLevelName.Equals ("intro2") || Application.loadedLevelName.Equals ("intro3"))
			secondAudioSource = GameObject.Find("GameObject").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro4")) 
			secondAudioSource = GameObject.Find("moth_push").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro6"))
			secondAudioSource = GameObject.Find("explosion_sky").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro7"))
			secondAudioSource = GameObject.Find("explosion_full").GetComponent<AudioSource>();
		
		if (Application.loadedLevelName.Equals ("intro9"))
			secondAudioSource = GameObject.Find("mothcounciessness").GetComponent<AudioSource>();

		audioSource.Stop ();

		if ( (   Application.loadedLevelName.Equals ("intro2") 
		      || Application.loadedLevelName.Equals ("intro3") 
		      || Application.loadedLevelName.Equals ("intro4")
		      || Application.loadedLevelName.Equals ("intro6")
		      || Application.loadedLevelName.Equals ("intro7")
		      || Application.loadedLevelName.Equals ("intro9")))
			secondAudioSource.Stop();
	}

	void Update()
	{
		int soundOn = PlayerPrefs.GetInt ("soundOn");

		if (soundOn == 1) {
			sound.SetActive (true);
			SoundONSelection ();
		} else {
			sound.SetActive (false);
			SoundOFFSelection ();
		}
	}
}
