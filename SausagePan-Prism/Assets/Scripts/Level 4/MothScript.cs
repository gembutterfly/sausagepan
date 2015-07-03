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
	public Image overlayImage;


	private ButtonScript colorButtonScript;
	private Animator animMoth1;
	private Animator animMoth2;
	private Color colorMoth1;
	private Color colorMoth2;
	private Color colorMoth1Comp;

	public void OnTriggerEnter2D (Collider2D other)
	{
		colorMoth1 = moth1.transform.GetChild (0).GetComponent<Image> ().color;
		colorMoth2 = moth2.transform.GetChild (0).GetComponent<Image> ().color;

		FindComplementaryColor (colorMoth1);

		if (colorMoth1Comp.Equals (colorMoth2)) 
		{
			PushBack ();
		} 
		else 
		{
			animMoth1.speed = 0;
			animMoth2.speed = 0;

			imgQuestion.SetActive(true);
			Invoke("PreReset", 4);
		}
	
	}

	public void PushBack()
	{
		explosion.SetActive (true);
		Invoke ("HideExplosion", 1);

		animMoth1.SetBool ("flying", false);
		animMoth1.SetBool ("pushBack", true);
		animMoth2.SetBool ("flying", false);
		animMoth2.SetBool ("pushBack", true);
	}

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

	public void Retry()
	{
		animMoth1.SetBool ("flying", false);
		animMoth1.SetBool ("pushBack", false);
		animMoth2.SetBool ("flying", false);
		animMoth2.SetBool ("pushBack", false);

		for (int i = 0; i < 3; i++) 
		{
			moth1.transform.GetChild(i).GetComponent<Image>().color = new Color (1, 1, 1, 1);
			moth2.transform.GetChild(i).GetComponent<Image>().color = new Color (1, 1, 1, 1);
		}

		retryButton.SetActive (false);
		FightButtonMessage ();
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

	void RetryButtonMessage()
	{
		retryButton.SetActive (true);
		retryButton.GetComponentInChildren<Text>().text = "Wiederholen";
	}

	void FightButtonMessage()
	{
		fightButton.SetActive (true);
		fightButton.GetComponentInChildren<Text> ().text = "Kampf";
	}

	void HideExplosion()
	{
		explosion.SetActive (false);
	}

	void PreReset()
	{
		imgQuestion.SetActive(false);
		
		animMoth1.speed = 1;
		animMoth2.speed = 1;
	}

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
