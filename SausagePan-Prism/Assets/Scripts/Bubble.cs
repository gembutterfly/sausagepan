using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	public GameObject bubble;
	
	public void OnTriggerEnter2D (Collider2D other)
	{
		Invoke ("HideBubble", 1);
		Invoke ("ShowBubble", 5);
	}

	// Use this for initialization
	void Start () 
	{
		bubble = this.gameObject;
	}

	void ShowBubble()
	{
		bubble.SetActive (true);
	}

	void HideBubble()
	{
		bubble.SetActive (false);
	}
}
