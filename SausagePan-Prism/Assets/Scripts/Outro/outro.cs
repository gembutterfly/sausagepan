using UnityEngine;
using System.Collections;

public class outro : MonoBehaviour {

	public int outrocount;
	private int zahl;
	private int[] time = new int[]{200, 200, 200, 100, 200, 320, 130, 270, 100, 100, 700};

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
		if (outrocount == 11)
			x += 0.007f;
		var help = colorFull.GetComponent<SpriteRenderer> ();
		help.color = new  Color(1f, 1f, 1f, x);
		x -= 0.009f;
	}

	private void nextOutro(){
		outrocount++;
		if (outrocount > 11)
			StartCoroutine ("ChangeLevel");
		else
			Application.LoadLevel ("outro" + outrocount);
	}

	public void Skip(){
		var go = GameObject.Find ("audio4");
		AudioSource help = go.GetComponent<AudioSource> ();
		help.Stop ();
		StartCoroutine ("ChangeLevel");
	}

	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		
		Application.LoadLevel ("Credits"); 
	}
}
