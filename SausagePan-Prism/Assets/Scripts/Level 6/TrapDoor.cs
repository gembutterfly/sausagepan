using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour {

	public Animator anim;

	public void OnCollisionEnter2D (Collision2D other) {
		Debug.Log ("1");
		if (other.collider.CompareTag ("Player")) 
		{
			Debug.Log ("2");
			anim.SetTrigger("openTrapdoor");
			Invoke ("closeTrapdoor",3);
		}
	}

	public void closeTrapdoor() {
		anim.SetTrigger("closeTrapdoor");
	}
}
