using UnityEngine;
using System.Collections;

public class Cloud_Absorbtion : MonoBehaviour {

	private Animator anim;




	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "GodRay") {
			anim = coll.gameObject.GetComponent<Animator> ();
			anim.SetBool ("IsBlocked", true);
			Debug.Log("I know it hit me");
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "GodRay") {
			anim = coll.gameObject.GetComponent<Animator> ();
			anim.SetBool ("IsBlocked", false);
			Debug.Log("I know it exited me");
		}
	}




}
