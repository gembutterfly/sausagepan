using UnityEngine;
using System.Collections;

public class switchExpl : MonoBehaviour {
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
	// Use this for initialization
	void Start () {
		order = new Sprite[9]{expl2, expl3, expl4, expl5, expl6, expl7, expl8, expl9, expl10};
	}
	
	// Update is called once per frame
	void Update () {
		if (wait == 0 && next < 9) {
			SpriteRenderer help = GetComponent<SpriteRenderer> ();

			help.sprite = order[next];
			wait = 200;
			next++;
		}
		wait--;
	}
}
