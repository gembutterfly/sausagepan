using UnityEngine;
using System.Collections;

public class DisplayManager : MonoBehaviour {

	public enum ObjectState
	{
		Prism,
		Glass,
		Raindrop
	};

	public enum RayState
	{
		White,
		Cyan,
		Magenta,
		Yellow,
		Red,
		Green,
		Blue
	};

	private ObjectState oState;
	private RayState rState;

	public GameObject prism;
	public GameObject glass;
	public GameObject raindrop;

	//Rays on the left side
	public GameObject white;
	public GameObject cyan;
	public GameObject magenta;
	public GameObject yellow;
	public GameObject red;
	public GameObject green;
	public GameObject blue;

	//Rays on the right side
	public GameObject white2;
	public GameObject cyan2;
	public GameObject magenta2;
	public GameObject yellow2;
	public GameObject red2;
	public GameObject green2;
	public GameObject blue2;

	// Use this for initialization
	void Start () {
		oState = ObjectState.Prism;
		rState = RayState.White;

		renderObjects ();
		renderRay ();
	}
	
	// Update is called once per frame
	void Update () {

		renderObjects ();
		renderRay ();
	
	}

	public void setObjectState(ObjectState state)
	{
		this.oState = state;
	}

	public void setRayState(RayState state)
	{
		this.rState = state;
	}

	public void renderObjects()
	{
		switch (oState) {
		case ObjectState.Prism: prism.SetActive(true); glass.SetActive(false); raindrop.SetActive(false); setPositionsforPrism(); break;
		case ObjectState.Glass: prism.SetActive(false); glass.SetActive(true); raindrop.SetActive(false); setPositionsforGlass(); break;
		case ObjectState.Raindrop: prism.SetActive(false); glass.SetActive(false); raindrop.SetActive(true); setPositionsforRaindrop(); break;
		}
	}

	public void renderRay()
	{
		switch (rState) {
		case RayState.White: white.SetActive (true); cyan.SetActive(false); magenta.SetActive(false); yellow.SetActive(false); red.SetActive(false); green.SetActive(false); blue.SetActive(false); break;
		case RayState.Cyan: white.SetActive (false); cyan.SetActive(true); magenta.SetActive(false); yellow.SetActive(false); red.SetActive(false); green.SetActive(false); blue.SetActive(false); break;
		case RayState.Magenta: white.SetActive (false); cyan.SetActive(false); magenta.SetActive(true); yellow.SetActive(false); red.SetActive(false); green.SetActive(false); blue.SetActive(false); break;
		case RayState.Yellow: white.SetActive (false); cyan.SetActive(false); magenta.SetActive(false); yellow.SetActive(true); red.SetActive(false); green.SetActive(false); blue.SetActive(false); break;
		case RayState.Red: white.SetActive (false); cyan.SetActive(false); magenta.SetActive(false); yellow.SetActive(false); red.SetActive(true); green.SetActive(false); blue.SetActive(false); break;
		case RayState.Green: white.SetActive (false); cyan.SetActive(false); magenta.SetActive(false); yellow.SetActive(false); red.SetActive(false); green.SetActive(true); blue.SetActive(false);break;
		case RayState.Blue: white.SetActive (false); cyan.SetActive(false); magenta.SetActive(false); yellow.SetActive(false); red.SetActive(false); green.SetActive(false); blue.SetActive(true);break;
		}
		renderSecondaryRay ();
	}

	public void renderSecondaryRay()
	{
		if (oState == ObjectState.Glass) {
			switch(rState)
			{
			case RayState.White:	white2.SetActive (true); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(false); blue2.SetActive(false); break;
			case RayState.Cyan:		white2.SetActive (false); cyan2.SetActive(true); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(false); blue2.SetActive(false); break;
			case RayState.Magenta:	white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(true); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(false); blue2.SetActive(false); break;
			case RayState.Yellow:	white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(true); red2.SetActive(false); green2.SetActive(false); blue2.SetActive(false); break;
			case RayState.Red:		white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(true); green2.SetActive(false); blue2.SetActive(false); break;
			case RayState.Green:	white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(true); blue2.SetActive(false); break;
			case RayState.Blue:		white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(false); blue2.SetActive(true); break;
			}
				return; 
		}
		switch (rState) {
		case RayState.White: white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(true); green2.SetActive(true); blue2.SetActive(true); break;
		case RayState.Cyan: white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(true); blue2.SetActive(true); break;
		case RayState.Magenta: white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(true); green2.SetActive(false); blue2.SetActive(true); break;
		case RayState.Yellow: white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(true); green2.SetActive(true); blue2.SetActive(false); break;
		case RayState.Red: white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(true); green2.SetActive(false); blue2.SetActive(false); break;
		case RayState.Green: white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(true); blue2.SetActive(false); break;
		case RayState.Blue: white2.SetActive (false); cyan2.SetActive(false); magenta2.SetActive(false); yellow2.SetActive(false); red2.SetActive(false); green2.SetActive(false); blue2.SetActive(true); break;
		}
	}

	private void setPositionsforPrism()
	{
		white.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		white.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		cyan.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		cyan.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		magenta.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		magenta.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		yellow.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		yellow.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		red.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		red.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		green.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		green.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		blue.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		blue.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		red2.GetComponent<RectTransform>().anchoredPosition = new Vector3(196, 36, 0);
		red2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 93.3000f);
		
		green2.GetComponent<RectTransform>().anchoredPosition = new Vector3(208, -15, 0);
		green2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 76.1000f);
		
		blue2.GetComponent<RectTransform>().anchoredPosition = new Vector3(197, -67, 0);
		blue2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 60.9000f);

	}

	void setPositionsforRaindrop()
	{
		white.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, 39, 0);
		white.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
		
		cyan.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, 39, 0);
		cyan.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
		
		magenta.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, 39, 0);
		magenta.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
		
		yellow.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, 39, 0);
		yellow.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
		
		red.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, 39, 0);
		red.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
		
		green.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, 39, 0);
		green.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
		
		blue.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, 39, 0);
		blue.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);

		//right
		red2.GetComponent<RectTransform>().anchoredPosition = new Vector3(-108, -132, 0);
		red2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 112.23f);
		
		green2.GetComponent<RectTransform>().anchoredPosition = new Vector3(-144, -122, 0);
		green2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 108);
		
		blue2.GetComponent<RectTransform>().anchoredPosition = new Vector3(-153, -100, 0);
		blue2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 103.3f);
	}

	void setPositionsforGlass()
	{
		white.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		white.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);
		
		cyan.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		cyan.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);
		
		magenta.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		magenta.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);
		
		yellow.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		yellow.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);
		
		red.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		red.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);
		
		green.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		green.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);
		
		blue.GetComponent<RectTransform>().anchoredPosition = new Vector3(-190, -56, 0);
		blue.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 292.6f);

		//right
		white2.GetComponent<RectTransform>().anchoredPosition = new Vector3(205, 50, 0);
		white2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 99.5707f);

		cyan2.GetComponent<RectTransform>().anchoredPosition = new Vector3(205, 50, 0);
		cyan2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 99.5707f);
		
		magenta2.GetComponent<RectTransform>().anchoredPosition = new Vector3(205, 50, 0);
		magenta2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 99.5707f);
		
		yellow2.GetComponent<RectTransform>().anchoredPosition = new Vector3(205, 50, 0);
		yellow2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 99.5707f);

		red2.GetComponent<RectTransform>().anchoredPosition = new Vector3(205, 50, 0);
		red2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 99.5707f);
		
		green2.GetComponent<RectTransform>().anchoredPosition = new Vector3(205, 50, 0);
		green2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 99.5707f);
		
		blue2.GetComponent<RectTransform>().anchoredPosition = new Vector3(205, 50, 0);
		blue2.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 99.5707f);

	}
}
