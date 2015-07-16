using UnityEngine;
using System.Collections;

public class HelpScript_Lvl5 : MonoBehaviour {

	public GameObject minigame;
	public GameObject helpText;
	public GameObject helpMenu;
	public GameObject backToTextBTN;
	
	/**
	 * Show minigame in help
	 * */
	public void ShowMinigame()
	{
		minigame.SetActive (true);
		helpText.SetActive (false);
		backToTextBTN.SetActive (true);
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
