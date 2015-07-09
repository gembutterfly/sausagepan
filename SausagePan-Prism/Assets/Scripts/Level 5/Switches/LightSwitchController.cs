using UnityEngine;
using System.Collections;

public class LightSwitchController : MonoBehaviour {

	private State lightState;

	public GameObject firstRay;
	public GameObject secondRay;

	public SpriteRenderer firefly;

	private enum State
	{
		First,
		Second
	};
	// Use this for initialization
	void Start () {
		lightState = State.Second;
		paintFirefly (secondRay.GetComponent<GodRay>().rayColor);


		secondRay.SetActive (true);
		firstRay.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
			

	}

	void OnMouseDown()
	{
		if(Input.GetMouseButtonDown(0))
		{
			switch(lightState)
			{
			case State.First: secondRay.SetActive(false); firstRay.SetActive(true); lightState = State.Second; paintFirefly (firstRay.GetComponent<GodRay>().rayColor); break;
			case State.Second: firstRay.SetActive(false); secondRay.SetActive(true); lightState = State.First; paintFirefly (secondRay.GetComponent<GodRay>().rayColor); break;
			}
		}

	}

	void paintFirefly(string colorName)
	{
		switch (colorName) {
		case "cyan": firefly.color = Color.cyan; break;
		case "magenta": firefly.color = Color.magenta; break;
		case "yellow": firefly.color = Color.yellow; break;
		}
	}
}
