using UnityEngine;
using System.Collections;

public class seq2_control : MonoBehaviour {
	public int scenecount;
	private int zahl;
	private int[] time = new int[]{170, 500, 1200, 200};

	public GameObject explanation;
	public Sprite expl2;
	public Sprite expl3;
	public Sprite expl4;
	public Sprite expl5;
	public Sprite expl6;

	private Sprite[] order;

	private int wait = 200;
	private int next = 0;
	private audio_intro audioIntro;

	// Use this for initialization
	void Start () {
		zahl = time [scenecount - 5];
		order = new Sprite[5]{expl2, expl3, expl4, expl5, expl6};
	}
	
	// Update is called once per frame
	void Update () {
		if (scenecount == 7) {
			if (wait == 0 && next < 5) {
				SpriteRenderer help = explanation.GetComponent<SpriteRenderer> ();
				
				help.sprite = order[next];
				wait = 200;
				next++;
			}
			wait--;
		}

		if (zahl == 0)
			nextScene ();
		else
			zahl--;
	
	}

	private void nextScene(){
		scenecount++;
		if (scenecount > 8) {
			audioIntro = GameObject.Find ("audio").GetComponent<audio_intro> ();
			audioIntro.Skip ();
			StartCoroutine ("ChangeLevel");
		}
		else
			Application.LoadLevel ("szene" + scenecount);
	}

	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		
		Application.LoadLevel ("Level5"); 
	}
}
