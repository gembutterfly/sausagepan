using UnityEngine;
using System.Collections;

public class Level6 : MonoBehaviour {
	public GameObject helpLevel6;
	public GameObject camera;

	public void ShowHelpMenu() {
		helpLevel6.SetActive(true);
	}

	public void Start() {
//		GameObject.Find ("blackBuddy").GetComponent<PlayerController>().enabled = false;
//		GameObject.Find ("Main Camera").GetComponent<Animator>().SetTrigger("panCamera");
//		Invoke ("ActivatePlayerController", 6);
	}

	public void ActivatePlayerController() {		
		GameObject.Find ("blackBuddy").GetComponent<PlayerController>().enabled = true;
	}
}
