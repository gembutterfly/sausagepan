using UnityEngine;
using System.Collections;

public class zwischenseq1 : MonoBehaviour {
	public int scenecount;
	private int zahl;
	private int[] time = new int[]{180, 150, 2000, 300};

	public GameObject explanation;
	public Sprite expl2;
	public Sprite expl3;
	public Sprite expl4;
	public Sprite expl5;
	public Sprite expl6;
	public Sprite expl7;
	public Sprite expl8;
	public Sprite expl9;
	public Sprite expl10;
	
	private Sprite[] order;
	
	private int wait = 200;
	private int next = 0;

	public GameObject lastScreen;
	public Sprite last;

	// Use this for initialization
	void Start () {
		zahl = time [scenecount - 1];
		order = new Sprite[9]{expl2, expl3, expl4, expl5, expl6, expl7, expl8, expl9, expl10};
	}
	
	// Update is called once per frame
	void Update () {
		if (scenecount == 3) {
			if (wait == 0 && next < 9) {
				SpriteRenderer help = explanation.GetComponent<SpriteRenderer> ();
				
				help.sprite = order[next];
				wait = 200;
				next++;
			}
			wait--;
		}

		if (scenecount == 4 && zahl == 150) {
			SpriteRenderer help = lastScreen.GetComponent<SpriteRenderer> ();
			
			help.sprite = last;
		}
		if (zahl == 0)
			nextScene ();
		else
			zahl--;
	}

	private void nextScene(){
		scenecount++;
		if (scenecount > 4)
			StartCoroutine ("ChangeLevel");
		else
			Application.LoadLevel ("szene" + scenecount);
	}

	public void Skip(){
		var go = GameObject.Find ("audio2");
		AudioSource help = go.GetComponent<AudioSource> ();
		help.Stop ();
		StartCoroutine ("ChangeLevel");
	}

	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		
		Application.LoadLevel ("LevelSelection"); 
	}
}
