using UnityEngine;
using System.Collections;

public class CorrectLightDetection : MonoBehaviour {
	
	public GameObject redRay;
	public GameObject greenRay;
	public GameObject blueRay;

	public WhiteRayEvent whiteRayEvent;
	public float shortValue = 1.6f;
	public float longValue = 1.8f;

	// Use this for initialization
	void Start () {
		redRay.SetActive (false);
		blueRay.SetActive (false);
		greenRay.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D whiteRay)
	{
		if (whiteRay.CompareTag ("White")) {
			redRay.SetActive(true);
			blueRay.SetActive(true);
			greenRay.SetActive (true);

			whiteRayEvent.cutRay(shortValue);
		}
	}

	void OnTriggerStay2D(Collider2D whiteRay)
	{
		if (whiteRay.CompareTag ("White")) {
			whiteRayEvent.cutRay(shortValue);
		}
	}

	void OnTriggerExit2D(Collider2D whiteRay)
	{
		if (whiteRay.CompareTag ("White")) {
			redRay.SetActive(false);
			blueRay.SetActive(false);
			greenRay.SetActive (false);

			whiteRayEvent.resizeRay(longValue);
		}
	}
}
