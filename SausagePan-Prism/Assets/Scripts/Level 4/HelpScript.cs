using UnityEngine;
using System.Collections;

public class HelpScript : MonoBehaviour {

	public GameObject minigame;
	public GameObject helpText;
	public GameObject helpMenu;
	public GameObject moth1;
	public GameObject moth2;
	public GameObject backToTextBTN;

	/**
	 * Show minigame in help
	 * */
	public void ShowMinigame()
	{
		minigame.SetActive (true);
		helpText.SetActive (false);
		backToTextBTN.SetActive (true);

//		moth1.GetComponent<Animator> ().enabled = true;
//		moth2.GetComponent<Animator> ().enabled = true;
	}

	/**
	 * Exit button of help menu
	 * */
	public void ExitHelpMenue()
	{
		helpMenu.SetActive (false);
		helpText.SetActive (true);
		minigame.SetActive (false);
		backToTextBTN.SetActive (false);

		// Call function that will reset moth1 and moth2
		moth1.GetComponent<MothScript> ().Retry ();
		moth2.GetComponent<MothScript> ().Retry ();
	}

	/**
	 * Set the minigame GameObject false and helpText one true
	 * */
	public void BackToHelpText()
	{
		helpText.SetActive (true);
		minigame.SetActive (false);
		backToTextBTN.SetActive (false);
	}
}
