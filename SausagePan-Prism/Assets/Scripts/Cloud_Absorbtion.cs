using UnityEngine;
using System.Collections;

public class Cloud_Absorbtion : MonoBehaviour {
	
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();

	}




	public void OnTriggerEnter2D(Collider2D coll) 
	{
		Debug.Log("I know it hit me");
		if (coll.CompareTag("GodRay")) {
			anim = coll.gameObject.GetComponent<Animator> ();
			anim.SetBool ("IsBlocked", true);
			Debug.Log("I know it hit me");
		}
	}

	public void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.CompareTag("GodRay")) {
			anim = coll.gameObject.GetComponent<Animator> ();
			Debug.Log(anim);
			anim.SetBool ("IsBlocked", false);
			anim.StartPlayback();
			Debug.Log("I know it exited me");
		}
	}



}
