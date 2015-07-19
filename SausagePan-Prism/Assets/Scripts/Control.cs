using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control : MonoBehaviour {

	public GameObject controlSettings;

	// Use this for initialization
	void Start () 
	{
		if (Application.loadedLevelName == "Level1") 
			Invoke("Show", 4);
		else
			Hide ();
	}

	public void Show()
	{
		controlSettings.SetActive (true);
	}

	public void Hide()
	{
		controlSettings.SetActive (false);
	}
}
