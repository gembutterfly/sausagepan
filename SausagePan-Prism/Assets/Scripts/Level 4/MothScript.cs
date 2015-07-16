using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MothScript : MonoBehaviour{

	public GameObject moth1;
	public GameObject moth2;
	public GameObject fightButton;
	public GameObject retryButton;
	public GameObject explosion;
	public GameObject imgQuestion;					
	public Image overlayImage;						// An image that overlay color buttons


	private ButtonScript colorButtonScript;
	private Animator animMoth1;
	private Animator animMoth2;
	private Color colorMoth1;
	private Color colorMoth2;
	private Color colorMoth1Comp;

	public void IsTriggered ()
	{
		colorMoth1 = moth1.transform.GetChild (0).GetComponent<Image> ().color;
		colorMoth2 = moth2.transform.GetChild (0).GetComponent<Image> ().color;

		FindComplementaryColor (colorMoth1);		// Call a function that convert a color to their complementary one

		if (colorMoth1Comp.Equals (colorMoth2)) 
		{
			PushBack ();							// Call a function that will play an push back animation
		} 
		else 
		{
			animMoth1.speed = 0;					// Set the animation speed to 0
			animMoth2.speed = 0;					// Set the animation speed to 0

			imgQuestion.SetActive(true);			// Activate a GameObject with an (question mark) image
			Invoke("PreReset", 4);					// After a delay of 4 seconds, it will call a function that reset the animation speed and disable imgQuestion GameObject
		}
	
	}

	/** 
	 * Play an (push back) animation
	 * */
	public void PushBack()
	{
		explosion.SetActive (true);					// Activate a GameObject with an (explosion) image
		Invoke ("HideExplosion", 1);				// After a delay of 1 second it will deactivate the (explosion) GameObject

		animMoth1.SetBool ("flying", false);
		animMoth1.SetBool ("pushBack", true);
		animMoth2.SetBool ("flying", false);
		animMoth2.SetBool ("pushBack", true);
	}

	/**
	 * Play an (fly) animation
	 * */
	public void Fight()
	{
		fightButton.SetActive (false);
		overlayImage.GetComponent<Image> ().enabled = true;

		animMoth1.SetBool ("flying", true);
		animMoth1.SetBool ("pushBack", false);
		animMoth2.SetBool ("flying", true);
		animMoth2.SetBool ("pushBack", false);

		Invoke ("RetryButtonMessage", 5);
	}

	/**
	 * Reset the animations and moths
	 * */
	public void Retry()
	{
		retryButton.SetActive (false);
		FightButtonMessage ();

		for (int i = 0; i < 3; i++) 
		{
			moth1.transform.GetChild(i).GetComponent<Image>().color = new Color (1, 1, 1, 1);
			moth2.transform.GetChild(i).GetComponent<Image>().color = new Color (1, 1, 1, 1);
		}

		ResetAnimations ();
	}

	public void ResetAnimations()
	{
		animMoth1.SetBool ("flying", false);
		animMoth1.SetBool ("pushBack", false);
		animMoth2.SetBool ("flying", false);
		animMoth2.SetBool ("pushBack", false);

		overlayImage.GetComponent<Image> ().enabled = false;

	}

	// Use this for initialization
	void Start () 
	{
		animMoth1 = moth1.GetComponent<Animator> ();
		animMoth2 = moth2.GetComponent<Animator> ();

		overlayImage.GetComponent<Image> ().enabled = false;

		FightButtonMessage ();
		retryButton.SetActive (false);
	}

	/**
	 * Set a message on retry button
	 * */
	void RetryButtonMessage()
	{
		retryButton.SetActive (true);
		retryButton.transform.GetChild (0).GetComponent<Text>().text = "Wiederholen";
	}

	/**
	 * Set a message on fight button
	 * */
	void FightButtonMessage()
	{
		fightButton.SetActive (true);
		fightButton.transform.GetChild (0).GetComponent<Text>().text = "Fliegen";
	}

	/**
	 * Deactivate (explosion) GameObject
	 * */
	void HideExplosion()
	{
		explosion.SetActive (false);
	}

	/**
	 * Deactivate (question mark) GameObject and reset the animation speed
	 * */
	void PreReset()
	{
		imgQuestion.SetActive(false);
		
		animMoth1.speed = 1;
		animMoth2.speed = 1;
	}

	/**
	 * Convert a color to their complementary color and set it on the colorMoth1Comp variable
	 * */
	void FindComplementaryColor(Color mothColor)
	{
		// Red -> Green
		if (mothColor == new Color (1, 0, 0, 1)) {
			colorMoth1Comp = new Color (0, 1, 0, 1);
		} 

		// Green -> Red
		if (mothColor == new Color (0, 1, 0, 1)) {
			colorMoth1Comp = new Color (1, 0, 0, 1);
		} 

		// Blue -> Orange
		if (mothColor == new Color (0, 0, 1, 1)) {
			colorMoth1Comp = new Color (1, 0.5F, 0, 1);
		} 

		// Orange -> Blue
		if (mothColor == new Color (1, 0.5F, 0, 1)) {
			colorMoth1Comp = new Color (0, 0, 1, 1);
		} 

		// Violet -> Yellow
		if (mothColor == new Color(0.64F, 0, 0.94F, 1)) {
			colorMoth1Comp = new Color (1, 1, 0, 1);
		} 

		// Yellow -> Violet
		if (mothColor == new Color (1, 1, 0, 1)) {
			colorMoth1Comp = new Color(0.64F, 0, 0.94F, 1);
		} 
	}
}
