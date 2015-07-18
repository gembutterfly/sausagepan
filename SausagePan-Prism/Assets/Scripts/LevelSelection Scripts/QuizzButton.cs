using UnityEngine;
using System.Collections;

public class QuizzButton : MonoBehaviour {
	
	public SwitchLevel level;
	
	private  SpriteRenderer moth;
	private static bool isClicked = false;
	// Use this for initialization
	void Start () {
		moth = GameObject.Find ("Quiz/moth_show").GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked)
			moth.enabled = false;
		else
			moth.enabled = true;
	}

	void OnMouseDown()
	{
		isClicked = true;
		level.goToLevel ("Quizze");
		//Application.LoadLevel ("Quizze");
	}
}
