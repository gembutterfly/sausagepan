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
		if (scenecount > 8)
			Application.LoadLevel ("Level5");
		else
			Application.LoadLevel ("szene" + scenecount);
	}
	
	public void Skip(){
		/*var go = GameObject.Find ("audio");
		AudioSource help = go.GetComponent<AudioSource> ();
		help.Stop ();*/
		Application.LoadLevel ("Level5");
	}
}
