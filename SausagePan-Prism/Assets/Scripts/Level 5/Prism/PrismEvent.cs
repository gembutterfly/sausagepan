using UnityEngine;
using System.Collections;

public class PrismEvent : MonoBehaviour {

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D littleGuy)
	{
		if (littleGuy.gameObject.CompareTag ("Player")) {
			rb2d.isKinematic = false;
		}
	}


}
