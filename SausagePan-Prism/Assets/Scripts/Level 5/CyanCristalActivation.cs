using UnityEngine;
using System.Collections;

public class CyanCristalActivation : MonoBehaviour {

	private bool isTouched = false;
	private Collider2D cristalCollider;
	private Collider2D littleGuy;
	
	public Collider2D firstRay;
	public Collider2D secondRay;
	// Use this for initialization
	void Start () {
		cristalCollider = GetComponent<Collider2D> ();
		littleGuy = GameObject.Find ("blackBuddy").GetComponent<Collider2D> ();
		Physics2D.IgnoreCollision (cristalCollider, littleGuy);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (cristalCollider.IsTouching (firstRay) && cristalCollider.IsTouching (secondRay))
			isTouched = true;
		else
			isTouched = false;
	}
	
	public bool getTouched()
	{
		return isTouched;
	}
}
