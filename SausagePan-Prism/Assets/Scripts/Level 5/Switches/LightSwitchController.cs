using UnityEngine;
using System.Collections;

public class LightSwitchController : MonoBehaviour {

	private State lightState;

	public GameObject firstRay;
	public GameObject secondRay;

	private enum State
	{
		First,
		Second
	};
	// Use this for initialization
	void Start () {
		lightState = State.Second;

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
			case State.First: secondRay.SetActive(false); firstRay.SetActive(true); lightState = State.Second; break;
			case State.Second: firstRay.SetActive(false); secondRay.SetActive(true); lightState = State.First; break;
			}
		}

	}
}
