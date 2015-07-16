using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** Don't forget to add a collider
 * */

public class SwitchOnLamps : MonoBehaviour {

	public Image ink;
//	public GameObject help;
//	public GameObject minigame;

	// Use this for initialization
	void Start () {
		ink.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ToggleActive() {
		if (ink.enabled)
			ink.enabled = false;
		else
			ink.enabled = true;
	}

//	public void SwitchToMinigame() {
//		help.SetActive(false);
//		minigame.SetActive(true);
//	}
//
//	public void SwitchToHelp() {
//		help.SetActive(true);
//		minigame.SetActive(false);
//	}
}
