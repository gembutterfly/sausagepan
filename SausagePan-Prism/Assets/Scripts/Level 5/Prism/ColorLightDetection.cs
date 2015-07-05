using UnityEngine;
using System.Collections;

public class ColorLightDetection : MonoBehaviour {

	public GameObject redRay;
	public GameObject greenRay;
	public GameObject blueRay;

	public ColorRayEvent cyanRayEvent;

	public ColorRayEvent magentaRayEvent;

	public ColorRayEvent yellowRayEvent;

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

	void OnTriggerEnter2D(Collider2D colorRay)
	{
		if (colorRay.CompareTag ("Cyan")) {
			redRay.SetActive (false);
			blueRay.SetActive(true);
			greenRay.SetActive (true);
			
			cyanRayEvent.cutRay(shortValue);
		}

		if (colorRay.CompareTag ("Magenta")) {
			greenRay.SetActive(false);
			blueRay.SetActive(true);
			redRay.SetActive (true);
			
			magentaRayEvent.cutRay(shortValue);
		}

		if (colorRay.CompareTag ("Yellow")) {
			blueRay.SetActive(false);
			redRay.SetActive(true);
			greenRay.SetActive (true);
			
			yellowRayEvent.cutRay(shortValue);
		}
	}
	
	void OnTriggerStay2D(Collider2D colorRay)
	{
		if (colorRay.CompareTag ("Cyan")) {
			cyanRayEvent.cutRay(shortValue);
		}

		if (colorRay.CompareTag ("Magenta")) {
			magentaRayEvent.cutRay(shortValue);
		}

		if (colorRay.CompareTag ("Yellow")) {
			yellowRayEvent.cutRay(shortValue);
		}
	}
	
	void OnTriggerExit2D(Collider2D colorRay)
	{
		if (colorRay.CompareTag ("Cyan")) {
			blueRay.SetActive(false);
			greenRay.SetActive (false);
			
			cyanRayEvent.resizeRay(longValue);
		}
		
		if (colorRay.CompareTag ("Magenta")) {
			blueRay.SetActive(false);
			redRay.SetActive (false);
			
			magentaRayEvent.resizeRay(longValue);
		}
		
		if (colorRay.CompareTag ("Yellow")) {
			redRay.SetActive(false);
			greenRay.SetActive (false);
			
			yellowRayEvent.resizeRay(longValue);
		}
	}
}
