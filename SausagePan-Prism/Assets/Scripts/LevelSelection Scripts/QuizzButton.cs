using UnityEngine;
using System.Collections;

public class QuizzButton : MonoBehaviour {
	
	public SwitchLevel level;
	public MeshRenderer meshRenderer;

	public GameObject moth;
	private static bool isClicked = false;

	public GameObject whiteLine;
	// Use this for initialization
	void Start () {
		meshRenderer.sortingOrder = 6;
		whiteLine.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked)
			moth.SetActive (false);
		else
			moth.SetActive (true);
	}

	void OnMouseOver()
	{
		whiteLine.SetActive (true);
	}

	void OnMouseExit()
	{
		whiteLine.SetActive (false);
	}

	void OnMouseDown()
	{
		isClicked = true;
		level.goToLevel ("Quizze");
		//Application.LoadLevel ("Quizze");
	}

	public void setClicked(bool value)
	{
		isClicked = value;
	}

}
