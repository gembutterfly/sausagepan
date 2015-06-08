using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control : MonoBehaviour {

	public CanvasGroup canvasGroup;
	public GameObject space;
	public GameObject right;
	public GameObject left;

	private bool goLeft;
	private bool goRight;
	private bool jump;

	// Use this for initialization
	void Start () 
	{
		GameObject controlImg = GameObject.FindGameObjectWithTag ("Control");
		canvasGroup = controlImg.GetComponent<CanvasGroup> ();

		if (Application.loadedLevelName == "Level1") 
			Show ();
		else
			Hide ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Jump")) {
			jump = true;
			space.SetActive(false);			
		}

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			goLeft = true;
			left.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			goRight = true;
			right.SetActive(false);
		}
		
		
		if((jump && goLeft) && goRight)
		{
			Hide();
		}
	}

	void Show()
	{
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}

	void Hide()
	{
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}
}
