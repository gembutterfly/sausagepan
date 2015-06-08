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

	public Image sound;

	// Use this for initialization
	void Start () {
		zahl = time [introcount - 1];

		if (AudioListener.volume.ToString ().Equals("0"))
			sound.enabled = false;
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
		Application.LoadLevel ("Level1");
	}

	public void soundOff(){
		AudioListener.volume = 0;
		sound.enabled = false;
	}

	public void soundOn(){
		AudioListener.volume = 1;
		sound.enabled = true;
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
			Application.LoadLevel ("Level1");
		else
			Application.LoadLevel ("intro" + introcount);
	}
}
