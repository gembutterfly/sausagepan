using UnityEngine;
using System.Collections;

public class HelpScript : MonoBehaviour {

	public GameObject minigame;
	public GameObject helpText;
	public GameObject helpMenu;
	public GameObject moth1;
	public GameObject moth2;
	public GameObject backToTextBTN;

	public void ShowMinigame()
	{
		minigame.SetActive (true);
		helpText.SetActive (false);
		backToTextBTN.SetActive (true);

//		moth1.GetComponent<Animator> ().enabled = true;
//		moth2.GetComponent<Animator> ().enabled = true;
	}

	public void ExitHelpMenue()
	{
		helpMenu.SetActive (false);
		helpText.SetActive (true);
		minigame.SetActive (false);
		backToTextBTN.SetActive (false);

		moth1.GetComponent<MothScript> ().Retry ();
		moth2.GetComponent<MothScript> ().Retry ();
	}
	
	public void BackToHelpText()
	{
		helpText.SetActive (true);
		minigame.SetActive (false);
		backToTextBTN.SetActive (false);
	}
}
