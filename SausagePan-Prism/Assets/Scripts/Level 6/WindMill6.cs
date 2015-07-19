using UnityEngine;
using System.Collections;

public class WindMill6 : MonoBehaviour {

	private Animator animCloud;
	private Animator animMill;
	private bool isClicked = false;
	private int cloudSet;
	
	void Start () {
		if (name == "Windmill1") {
			animCloud = GameObject.Find ("Cloud_blue").GetComponent<Animator> ();
			cloudSet = 1;
			isClicked = true;
		}
		if (name == "Windmill2") {
			animCloud = GameObject.Find ("Cloud_red").GetComponent<Animator> ();
			cloudSet = 2;
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
			if(cloudSet == 2)
				animCloud.SetTrigger ("cloudOut");
			else
				animCloud.SetTrigger ("cloudIn");
		} else {
			isClicked = true;
			if(cloudSet == 1)
				animCloud.SetTrigger ("cloudOut");
			else
				animCloud.SetTrigger ("cloudIn");
		}

		if(cloudSet == 2)
			animMill.SetBool ("IsClicked", isClicked);
		else
			animMill.SetBool ("IsClicked", !isClicked);
		
	} 
}
