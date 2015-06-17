using UnityEngine;
using System.Collections;

public class Windmill : MonoBehaviour {
	
	private Animator animCloud;
	private Animator animMill;

	void Start () {
		animCloud = GameObject.Find("CloudSet_1").GetComponent<Animator> ();
		animMill = GetComponent<Animator> ();
	}


	void OnMouseDown(){
		animCloud.SetBool ("IsMoved", true);
		animMill.SetBool ("IsClicked", true);

	} 
}
