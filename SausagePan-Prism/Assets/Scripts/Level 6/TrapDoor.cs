using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour {

	public Animator anim;

	public void OnCollisionEnter2D (Collision2D other) {
		if (other.collider.CompareTag ("Player")) 
		{
			anim.SetTrigger("openTrapdoor");
			Invoke ("closeTrapdoor",3);
		}
	}

	public void closeTrapdoor() {
		anim.SetTrigger("closeTrapdoor");
	}
}
