using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class intro : MonoBehaviour {
	public int introcount;
	private int zahl;
	private int[] time = new int[]{230, 770, 440, 250, 500, 60, 150, 200, 300};

	public GameObject colorFull;
	private float x = 1;

	public GameObject explosion;
	private int size = 0;

	public GameObject eyes;
	public GameObject hitSound;

	private Fading fading;

	// Use this for initialization
	void Start () {
		zahl = time [introcount - 1];

		fading = GameObject.Find ("Main Camera").GetComponent<Fading> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (colorFull != null)
			if (x <= 0)
				nextIntro ();
			else
				changeOpacity ();

		if (explosion != null && zahl < 400)
			if (size > 30)
				nextIntro ();
			else
				explosionSize ();

		if ((introcount == 4) && (zahl == 120)) {
			var help = eyes.GetComponent<SpriteRenderer>();
			help.sortingOrder = -1;

			AudioSource y = hitSound.GetComponent<AudioSource>();
			y.Play();
		}

		if (zahl == 0)
			nextIntro ();
		else
			zahl--;

	}

	public void Skip(){
		var go = GameObject.Find ("audio");
		AudioSource help = go.GetComponent<AudioSource> ();
		help.Stop ();
		StartCoroutine ("ChangeLevel");
	}

	private void changeOpacity(){
		var help = colorFull.GetComponent<SpriteRenderer> ();
		help.color = new  Color(1f, 1f, 1f, x);
		x -= 0.01f;
	}

	private void explosionSize(){
		var help = explosion.GetComponent<SpriteRenderer> ();
		help.sortingOrder = 2;

		var help2 = explosion.GetComponent<Transform>();
		help2.localScale += new Vector3(0.3F, 0.3F, 0);

		size++;
	}

	private void nextIntro(){
		introcount++;
		if (introcount > 9)
			StartCoroutine ("ChangeLevel");
		else
			Application.LoadLevel ("intro" + introcount);
	}

	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		
		Application.LoadLevel ("Level1");
	}
}
