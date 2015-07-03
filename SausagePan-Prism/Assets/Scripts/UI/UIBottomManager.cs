using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UIBottomManager : MonoBehaviour {

	// Color circles
	public List<GameObject> colorCircleXL = new List<GameObject>();
	public List<GameObject> colorCircleXS = new List<GameObject>();

	// Black and white cloud
	public GameObject blackCloud;
	public GameObject whiteCloud;

	// Help menu
	public GameObject helpMenu;

	GameObject player;
	bool blackCloudIsActive = false;
	bool whiteCloudIsActive = false;
	
	bool lightColorCircleXL_isActive = true;


	List<Color> fullColorList = new List<Color> ();


	public void SwitchToRight()
	{
		LightColorCircleXL();
		ColorColorCircleXS ();

		lightColorCircleXL_isActive = true;
	}

	public void SwitchToLeft()
	{
		ColorColorCircleXL ();
		LightColorCircleXS ();

		lightColorCircleXL_isActive = false;
	}

	// Open help menu
	public void HelpMenu()
	{
		helpMenu.SetActive (true);
	}

	public void CallBlackCloud()
	{
		if (!blackCloudIsActive) 
		{
			if(whiteCloudIsActive)
			{
				ResetWhiteCloud();

				blackCloudIsActive = true;
				
				blackCloud.SetActive (true);
				blackCloud.GetComponent<Transform> ().localPosition = new Vector3 (player.GetComponent<Transform> ().localPosition.x,
				                                                                   player.GetComponent<Transform> ().localPosition.y + 5,
				                                                                   player.GetComponent<Transform> ().localPosition.z);
				Invoke ("ResetBlackCloud", 5);
			}
			else
			{
				blackCloudIsActive = true;
				
				blackCloud.SetActive (true);
				blackCloud.GetComponent<Transform> ().localPosition = new Vector3 (player.GetComponent<Transform> ().localPosition.x,
				                                                                   player.GetComponent<Transform> ().localPosition.y + 5,
				                                                                   player.GetComponent<Transform> ().localPosition.z);
				Invoke ("ResetBlackCloud", 5);
			}
		}
	}
	
	public void CallWhiteCloud()
	{
		if (!whiteCloudIsActive) 
		{
			if(blackCloudIsActive)
			{
				ResetBlackCloud();

				whiteCloudIsActive = true;
				
				whiteCloud.SetActive (true);
				whiteCloud.GetComponent<Transform> ().localPosition = new Vector3 (player.GetComponent<Transform> ().localPosition.x,
				                                                                   player.GetComponent<Transform> ().localPosition.y + 5,
				                                                                   player.GetComponent<Transform> ().localPosition.z);
				Invoke ("ResetWhiteCloud", 5);
			}
			else
			{
				whiteCloudIsActive = true;
				
				whiteCloud.SetActive (true);
				whiteCloud.GetComponent<Transform> ().localPosition = new Vector3 (player.GetComponent<Transform> ().localPosition.x,
				                                                                   player.GetComponent<Transform> ().localPosition.y + 5,
				                                                                   player.GetComponent<Transform> ().localPosition.z);
				Invoke ("ResetWhiteCloud", 5);
			}
		}
	}

	public void InitializeFullColorList(List<Color> colorList)
	{
		fullColorList.Clear ();
		
		// Initialize fullColorList
		fullColorList.Add (new Color (1, 1, 1, 1)); // 0 white
		fullColorList.Add (new Color (1, 1, 0, 1)); // 1 yellow
		fullColorList.Add (new Color (1, 0, 1, 1)); // 2 magenta
		fullColorList.Add (new Color (1, 0, 0, 1)); // 3 red
		fullColorList.Add (new Color (0, 1, 1, 1)); // 4 cyan
		fullColorList.Add (new Color (0, 1, 0, 1)); // 5 green
		fullColorList.Add (new Color (0, 0, 1, 1)); // 6 blue
		fullColorList.Add (new Color (0, 0, 0, 1)); // 7 black
		
		FillColorCircle (colorList);
	}

	public void FillColorCircle(List<Color> colorList)
	{
		int i = 0;
		int j = 0;


		List<int> tempColorIDList = new List<int> {0, 1, 2, 3, 4, 5, 6, 7};

		foreach(Color cl in colorList.ToList())
		{
			foreach(Color fcl in fullColorList.ToList())
			{
				if(cl.Equals(fcl))
				{
					foreach(int tcIDl in tempColorIDList.ToList())
					{
						tempColorIDList.Remove(i);
					}

					//Debug.Log ("tempColorIDList " + tempColorIDList.Count);
				}

				i++;
			}

			i = 0;
		}

		tempColorIDList.Sort ();

		foreach(Color fcl in fullColorList.ToList())
		{
			foreach(int tcIDl in tempColorIDList)
			{
				if(j == tcIDl)
				{
					fullColorList[j] = colorList[0];
				}
			}

			j++;
		}

		//Debug.Log ("tempColorIDList " + tempColorIDList.Count);

		
		if (lightColorCircleXL_isActive)
			SwitchToRight ();
		else
			SwitchToLeft ();
	}

	/**
	 * Color Circle
	 * 
	 * 0 = bottom_left
	 * 1 = bottom_right
	 * 2 = top_left
	 * 3 = top_right
	 * 4 = top_mid
	 * 5 = mid
	 * 6 = bottom
	 * */
	void LightColorCircleXL()
	{
		colorCircleXL [0].GetComponent<Image> ().color = fullColorList[4]; // cyan
		colorCircleXL [1].GetComponent<Image> ().color = fullColorList[1]; // yellow
		colorCircleXL [2].GetComponent<Image> ().color = fullColorList[6]; // blue
		colorCircleXL [3].GetComponent<Image> ().color = fullColorList[3]; // red 
		colorCircleXL [4].GetComponent<Image> ().color = fullColorList[2]; // magenta
		colorCircleXL [5].GetComponent<Image> ().color = fullColorList[0]; // white 
		colorCircleXL [6].GetComponent<Image> ().color = fullColorList[5]; // green
	}

	void ColorColorCircleXL()
	{
		colorCircleXL [0].GetComponent<Image> ().color = fullColorList[6]; // blue
		colorCircleXL [1].GetComponent<Image> ().color = fullColorList[3]; // red 
		colorCircleXL [2].GetComponent<Image> ().color = fullColorList[4]; // cyan 
		colorCircleXL [3].GetComponent<Image> ().color = fullColorList[1]; // yellow 
		colorCircleXL [4].GetComponent<Image> ().color = fullColorList[5]; // green
		colorCircleXL [5].GetComponent<Image> ().color = fullColorList[7]; // black 
		colorCircleXL [6].GetComponent<Image> ().color = fullColorList[2]; // magenta 
	}

	void LightColorCircleXS()
	{
		colorCircleXS [0].GetComponent<Image> ().color = fullColorList[4]; // cyan
		colorCircleXS [1].GetComponent<Image> ().color = fullColorList[1]; // yellow
		colorCircleXS [2].GetComponent<Image> ().color = fullColorList[6]; // blue
		colorCircleXS [3].GetComponent<Image> ().color = fullColorList[3]; // red 
		colorCircleXS [4].GetComponent<Image> ().color = fullColorList[2]; // magenta
		colorCircleXS [5].GetComponent<Image> ().color = fullColorList[0]; // white 
		colorCircleXS [6].GetComponent<Image> ().color = fullColorList[5]; // green
	}
	
	void ColorColorCircleXS()
	{
		colorCircleXS [0].GetComponent<Image> ().color = fullColorList[6]; // blue
		colorCircleXS [1].GetComponent<Image> ().color = fullColorList[3]; // red 
		colorCircleXS [2].GetComponent<Image> ().color = fullColorList[4]; // cyan 
		colorCircleXS [3].GetComponent<Image> ().color = fullColorList[1]; // yellow 
		colorCircleXS [4].GetComponent<Image> ().color = fullColorList[5]; // green
		colorCircleXS [5].GetComponent<Image> ().color = fullColorList[7]; // black 
		colorCircleXS [6].GetComponent<Image> ().color = fullColorList[2]; // magenta 
	}

	void ResetBlackCloud()
	{
		blackCloud.SetActive (false);
		blackCloudIsActive = false;
	}
	
	void ResetWhiteCloud()
	{
		whiteCloud.SetActive (false);
		whiteCloudIsActive = false;
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
}