using UnityEngine;
using System.Collections;

public class WindMill6 : MonoBehaviour {

	private Animator animCloud;
	private Animator animMill;
	private bool isClicked = false;
	private int cloudSet;
	private Level6 l6;
	
	void Start () {
		l6 = GameObject.Find ("UIManager").GetComponent<Level6>();
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
			if(cloudSet == 2) {
				animCloud.SetTrigger ("cloudOut");
				Invoke("DeactivateRedCloud", 0.3f);
			} else {
				animCloud.SetTrigger ("cloudIn");
				Invoke("ActivateBlueCloud", 1.4f);
			}
		} else {
			isClicked = true;
			if(cloudSet == 1) {
				animCloud.SetTrigger ("cloudOut");
				Invoke("DeactivateBlueCloud", 0.1f);
			} else {
				animCloud.SetTrigger ("cloudIn");
				Invoke("ActivateRedCloud", 1.0f);
			}
		}

		if(cloudSet == 2)
			animMill.SetBool ("IsClicked", isClicked);
		else
			animMill.SetBool ("IsClicked", !isClicked);
	}

	void ActivateRedCloud() {
		l6.SetCloud(2, true);
	}
	void DeactivateRedCloud() {
		l6.SetCloud(2, false);
	}
	void ActivateBlueCloud() {
		l6.SetCloud(1, true);
	}
	void DeactivateBlueCloud() {
		l6.SetCloud(1, false);
	}
}
