using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	private Canvas canvas;
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		GameObject controlImg = GameObject.FindGameObjectWithTag ("Finish");
		canvas = controlImg.GetComponent<Canvas> ();
		anim = controlImg.GetComponent<Animator> ();
		Hide ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			Show ();
		}
	}

	void Show()
	{
		canvas.enabled = true;
		anim.enabled = true;
	}
	
	void Hide()
	{
		canvas.enabled = false;
		anim.enabled = false;
	}
}
