using UnityEngine;
using System.Collections;

public class CyanDoorEvent : MonoBehaviour {

	private SpriteRenderer door;
	private Collider2D doorCollider;
	public Collider2D littleGuy;
	public SpriteRenderer littleGuyColor;
	
	public CyanCristalActivation cyanCristal;
	
	// Use this for initialization
	void Start () {
		door = GetComponent<SpriteRenderer> ();
		door.enabled = false;
		
		doorCollider = GetComponent<Collider2D> ();
		doorCollider.enabled = false;
		
		littleGuy = GameObject.Find ("blackBuddy").GetComponent<Collider2D> ();
		littleGuyColor = GameObject.Find ("blackBuddy/textures/body").GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (cyanCristal.getTouched ()) {
			door.enabled = true;
			doorCollider.enabled = true;
		}
		
		if (doorCollider.IsTouching (littleGuy) && littleGuyColor.color.Equals (Color.magenta)) {
			Application.Quit();
		}
		
	}
}
