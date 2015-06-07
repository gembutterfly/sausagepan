using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {
	public int introcount;
	private int zahl;
	private int[] time = new int[]{230, 770, 440, 500, 60, 150, 200, 300};

	public GameObject colorFull;
	private float x = 1;

	public GameObject explosion;
	private int size = 0;

	// Use this for initialization
	void Start () {
		zahl = time [introcount - 1];
	}
	
	// Update is called once per frame
	void Update () {
		if (colorFull != null)
			if (x <= 0)
				nextIntro ();
			else
				changeOpacity ();

		if (explosion != null)
			if (size > 30)
				nextIntro ();
			else
				explosionSize ();	

		if (zahl == 0)
			nextIntro ();
		else
			zahl--;

	}

	public void Skip(){
		Application.LoadLevel ("Level1");
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
		if (introcount > 8)
			Application.LoadLevel ("Level1");
		else
			Application.LoadLevel ("intro" + introcount);
	}
}
