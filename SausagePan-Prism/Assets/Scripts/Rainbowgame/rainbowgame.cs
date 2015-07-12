using UnityEngine;
using System.Collections;

public class rainbowgame : MonoBehaviour {

	public GameObject color1;
	public GameObject color2;
	public GameObject color3;
	public GameObject color4;
	public GameObject color5;
	public GameObject color6;
	public GameObject color7;

	public GameObject lighty;
	public Sprite light_help;
	public Sprite light_full;

	public GameObject excl;

	private int zahl = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		zahl --;
		if (zahl == 0) {
			SpriteRenderer help = color1.GetComponent<SpriteRenderer>();
			help.color = Color.red;

			help = color7.GetComponent<SpriteRenderer>();
			help.color = new Color32(131, 4, 251, 255);

			help = lighty.GetComponent<SpriteRenderer>();
			help.sprite = light_help;

			excl.SetActive(false);
		}

	}
}
