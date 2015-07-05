using UnityEngine;
using System.Collections;

public class Windmill : MonoBehaviour {
	
	private Animator animCloud;
	private Animator animMill;
	private bool isClicked = false;
	private int cloudSet;

	void Start () {
		if (name == "windmill_stand_1") {
			animCloud = GameObject.Find ("CloudSet_1").GetComponent<Animator> ();
			cloudSet = 1;
		}
		if (name == "windmill_stand_2") {
			animCloud = GameObject.Find ("CloudSet_2").GetComponent<Animator> ();
			cloudSet = 2;
		}
		if (name == "windmill_stand_3") {
			animCloud = GameObject.Find ("CloudSet_2").GetComponent<Animator> ();
			cloudSet = 3;
		}
		if (name == "windmill_stand_4") {
			animCloud = GameObject.Find ("CloudSet_2").GetComponent<Animator> ();
			cloudSet = 4;
		}


		animMill = GetComponent<Animator> ();
	}

	void OnMouseEnter() {
		gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
	}
	
	void OnMouseExit() {
		gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
	}

	void OnMouseDown(){

		if (isClicked == true) {
			isClicked = false;
			animCloud.SetInteger ("CloudSet", cloudSet * (-1));
		} else {
			isClicked = true;
		animCloud.SetInteger ("CloudSet", cloudSet);
		}

		animMill.SetBool ("IsClicked", isClicked);

	} 
}
