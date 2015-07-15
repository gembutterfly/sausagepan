using UnityEngine;
using System.Collections;

public class outro : MonoBehaviour {

	public int outrocount;
	private int zahl;
	private int[] time = new int[]{200, 200, 300, 320, 500, 60, 150, 200, 300};

	public GameObject colorFull;
	private float x = 1;

	// Use this for initialization
	void Start () {
		zahl = time [outrocount - 1];	
	}
	
	// Update is called once per frame
	void Update () {
		if (colorFull != null)
			if (x <= 0)
				nextOutro ();
		else
			changeOpacity ();

		if (zahl == 0)
			nextOutro ();
		else
			zahl--;
	}

	private void changeOpacity(){
		var help = colorFull.GetComponent<SpriteRenderer> ();
		help.color = new  Color(1f, 1f, 1f, x);
		x -= 0.009f;
	}

	private void nextOutro(){
		outrocount++;
		if (outrocount > 9)
			Application.LoadLevel ("Credits");
		else
			Application.LoadLevel ("outro" + outrocount);
	}
}
