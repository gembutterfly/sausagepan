using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	private MothScript mothScript;

	public void OnTriggerEnter2D (Collider2D other)
	{
		mothScript.IsTriggered ();	
	}

	// Use this for initialization
	void Start () 
	{
		mothScript = GameObject.Find ("HelpManager").GetComponent<MothScript> ();
	}
}
