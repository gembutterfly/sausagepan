using UnityEngine;
using System.Collections;

public class QuizzButton : MonoBehaviour {
	
	public SwitchLevel level;
	public MeshRenderer meshRenderer;

	public GameObject moth;
	private static bool isClicked = false;
	// Use this for initialization
	void Start () {
		meshRenderer.sortingOrder = 6;

	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked)
			moth.SetActive (false);
		else
			moth.SetActive (true);
	}

	void OnMouseDown()
	{
		isClicked = true;
		level.goToLevel ("Quizze");
		//Application.LoadLevel ("Quizze");
	}

}
