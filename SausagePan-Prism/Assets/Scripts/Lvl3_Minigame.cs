using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Lvl3_Minigame : MonoBehaviour, IPointerDownHandler {

	public Image Light1;					//oberstes Licht
	public Image Light2;					//mittleres Licht
	public Image Light3;					//unteres Licht
	public Image Cloud1;					//obere Wolke
	public Image Cloud2;					//untere Wolke
	public string buttonColorLight;				// String (color) of light button
	public string buttonColorCloud1;				// String (color) of cloud1 button
	public string buttonColorCloud2;				// String (color) of cloud2 button
	
	private Color colorLight;
	private Color colorCloud1;
	private Color colorCloud2;

	private Color red = new Color (1, 0.31f, 0.31f, 1);
	private Color green = new Color (0.31f, 1, 0.31f, 1);
	private Color blue = new Color(0.31f, 0.31f, 1, 1);
	private Color cyan = new Color (0.31f, 1, 1, 1);
	private Color magenta = new Color(1, 0.31f, 1, 1);
	private Color yellow = new Color(1, 1, 0.31f, 1);
	
	public void OnPointerDown(PointerEventData data)
	{
		if (buttonColorLight != "")
			colorLight = GetColor (buttonColorLight);
		if (buttonColorCloud1 != "")
			colorCloud1 = GetColor (buttonColorCloud1);
		if (buttonColorCloud2 != "")
			colorCloud2 = GetColor (buttonColorCloud2);

		ColorStuff ();						
	}

	/**
	 * Convert (string) color to Color
	 * */
	UnityEngine.Color GetColor(string btnColor)
	{
		switch (btnColor) 
		{
		case "red": 
			return red;
		case "green": 
			return green;
		case "blue": 
			return blue;
		case "cyan": 
			return cyan;
		case "magenta":
			return magenta;
		case "yellow": 
			return yellow;
		default: 
			Debug.Log("no color detected or spelling misstake");
			return red; 

		}
	}

	void ColorStuff() {
		//ajust color selection
		if (buttonColorCloud1 != "")
			Cloud1.color = colorCloud1;
		if (buttonColorCloud2 != "")
			Cloud2.color = colorCloud2;
		if (buttonColorLight != "")
			Light1.color = colorLight;

		//calculate changes in light and do stuff
		//redLight
		if (Light1.color == red) { 
			//red+yellow+magentaC1
			if (Cloud1.color == red || Cloud1.color == yellow ||
			    Cloud1.color == magenta) { 
				Light2.enabled = false;
				Light3.enabled = false;
			}
			//green+blue+cyanC1
			if (Cloud1.color == green || Cloud1.color == blue || 
			    Cloud1.color == cyan) { 
					Light2.enabled = true;
					Light2.color = red;
				//red+yellow+magentaC2
				if (Cloud2.color == red || Cloud2.color == yellow ||
				    Cloud2.color == magenta) 
						Light3.enabled = false;
				//green+blue+cyanC2
				if (Cloud2.color == green || Cloud2.color == blue || 
				    Cloud2.color == cyan) {
						Light3.enabled = true;
						Light3.color = red;
				}
			}

		}
		//greenLight
		if (Light1.color == green) {
			//green+yellow+cyanC1
			if (Cloud1.color == green || Cloud1.color == yellow ||
			    Cloud1.color == cyan) { 
				Light2.enabled = false;
				Light3.enabled = false;
			}
			//red+blue+magentaC1
			if (Cloud1.color == red || Cloud1.color == blue || 
			    Cloud1.color == magenta) { 
				Light2.enabled = true;
				Light2.color = green;
				//green+yellow+cyanC2
				if (Cloud2.color == green || Cloud2.color == yellow ||
				    Cloud2.color == cyan) 
					Light3.enabled = false;
				//red+blue+magentaC2
				if (Cloud2.color == red || Cloud2.color == blue || 
				    Cloud2.color == magenta) {
					Light3.enabled = true;
					Light3.color = green;
				}
			}
		}
		//blueLight
		if (Light1.color == blue) {
			//blue+magenta+cyanC1
			if (Cloud1.color == blue || Cloud1.color == magenta ||
			    Cloud1.color == cyan) { 
				Light2.enabled = false;
				Light3.enabled = false;
			}
			//red+green+yellowC1
			if (Cloud1.color == red || Cloud1.color == green || 
			    Cloud1.color == yellow) { 
				Light2.enabled = true;
				Light2.color = blue;
				//blue+magenta+cyanC2
				if (Cloud2.color == blue || Cloud2.color == magenta ||
				    Cloud2.color == cyan) 
					Light3.enabled = false;
				//red+green+yellowC2
				if (Cloud2.color == red || Cloud2.color == green || 
				    Cloud2.color == yellow) {
					Light3.enabled = true;
					Light3.color = blue;
				}
			}
		}
		//cyanLight
		if (Light1.color == cyan) {
			//cyanC1
			if (Cloud1.color == cyan) { 
				Light2.enabled = false;
				Light3.enabled = false;
			}
			//green+yellowC1
			if (Cloud1.color == green || Cloud1.color == yellow) { 
				Light2.enabled = true;
				Light2.color = blue;
				//blue+magenta+cyanC2
				if (Cloud2.color == blue || Cloud2.color == magenta ||
				    Cloud2.color == cyan) 
					Light3.enabled = false;
				//red+green+yellowC2
				if (Cloud2.color == red || Cloud2.color == green || 
				    Cloud2.color == yellow) {
					Light3.enabled = true;
					Light3.color = blue;
				}
			}
			//blue+magentaC1
			if (Cloud1.color == blue || Cloud1.color == magenta) {
				Light2.enabled = true;
				Light2.color = green;
				//green+yellow+cyanC2
				if (Cloud2.color == green || Cloud2.color == yellow ||
				    Cloud2.color == cyan) 
					Light3.enabled = false;
				//red+blue+magentaC2
				if (Cloud2.color == red || Cloud2.color == blue || 
				    Cloud2.color == magenta) {
					Light3.enabled = true;
					Light3.color = green;
				}
			}
			//redC1
			if (Cloud1.color == red) {
				Light2.enabled = true;
				Light2.color = cyan;
				//cyanC2
				if (Cloud2.color == cyan) 
					Light3.enabled = false;
				//green+yellowC2
				if (Cloud2.color == green || Cloud2.color == yellow) { 
					Light3.enabled = true;
					Light3.color = blue;
				}
				//blue+magentaC2
				if (Cloud2.color == blue || Cloud2.color == magenta) {
					Light3.enabled = true;
					Light3.color = green;
				}
				//redC2
				if (Cloud2.color == red) {
					Light3.enabled = true;
					Light3.color = cyan;
				}
			}
		}
		//magentaLight
		if (Light1.color == magenta) {
			//magentaC1
			if (Cloud1.color == magenta) { 
				Light2.enabled = false;
				Light3.enabled = false;
			}
			//red+yellowC1
			if (Cloud1.color == red || Cloud1.color == yellow) { 
				Light2.enabled = true;
				Light2.color = blue;
				//blue+magenta+cyanC2
				if (Cloud2.color == blue || Cloud2.color == magenta ||
				    Cloud2.color == cyan) 
					Light3.enabled = false;
				//red+green+yellowC2
				if (Cloud2.color == red || Cloud2.color == green || 
				    Cloud2.color == yellow) {
					Light3.enabled = true;
					Light3.color = blue;
				}
			}
			//blue+cyanC1
			if (Cloud1.color == blue || Cloud1.color == cyan) {
				Light2.enabled = true;
				Light2.color = red;
				//red+yellow+magentaC2
				if (Cloud2.color == red || Cloud2.color == yellow ||
				    Cloud2.color == magenta) 
					Light3.enabled = false;
				//green+blue+cyanC2
				if (Cloud2.color == green || Cloud2.color == blue || 
				    Cloud2.color == cyan) {
					Light3.enabled = true;
					Light3.color = red;
				}
			}
			//greenC1
			if (Cloud1.color == green) {
				Light2.enabled = true;
				Light2.color = magenta;
				//magentaC2
				if (Cloud2.color == magenta) 
					Light3.enabled = false;
				//red+yellowC2
				if (Cloud2.color == red || Cloud2.color == yellow) { 
					Light3.enabled = true;
					Light3.color = blue;
				}
				//blue+cyanC2
				if (Cloud2.color == blue || Cloud2.color == cyan) {
					Light3.enabled = true;
					Light3.color = red;
				}
				//greenC2
				if (Cloud2.color == green) {
					Light3.enabled = true;
					Light3.color = magenta;
				}
			}
		}
		//yellowLight
		if (Light1.color == yellow) {
			//yellowC1
			if (Cloud1.color == yellow) { 
				Light2.enabled = false;
				Light3.enabled = false;
			}
			//red+magentaC1
			if (Cloud1.color == red || Cloud1.color == magenta) { 
				Light2.enabled = true;
				Light2.color = green;
				//green+yellow+cyanC2
				if (Cloud2.color == green || Cloud2.color == yellow ||
				    Cloud2.color == cyan) 
					Light3.enabled = false;
				//red+blue+magentaC2
				if (Cloud2.color == red || Cloud2.color == blue || 
				    Cloud2.color == magenta) {
					Light3.enabled = true;
					Light3.color = green;
				}
			}
			//green+cyanC1
			if (Cloud1.color == green || Cloud1.color == cyan) {
				Light2.enabled = true;
				Light2.color = red;
				//red+yellow+magentaC2
				if (Cloud2.color == red || Cloud2.color == yellow ||
				    Cloud2.color == magenta) 
					Light3.enabled = false;
				//green+blue+cyanC2
				if (Cloud2.color == green || Cloud2.color == blue || 
				    Cloud2.color == cyan) {
					Light3.enabled = true;
					Light3.color = red;
				}
			}
			//blueC1
			if (Cloud1.color == blue) {
				Light2.enabled = true;
				Light2.color = yellow;
				//yellowC2
				if (Cloud2.color == yellow) 
					Light3.enabled = false;
				//red+magentaC2
				if (Cloud2.color == red || Cloud2.color == magenta) { 
					Light3.enabled = true;
					Light3.color = green;
				}
				//green+cyanC2
				if (Cloud2.color == green || Cloud2.color == cyan) {
					Light3.enabled = true;
					Light3.color = red;
				}
				//blueC2
				if (Cloud2.color == blue) {
					Light3.enabled = true;
					Light3.color = yellow;
				}
			}
		}
	}


	// Use this for initialization
	void Start () {
	
		Cloud1.color = new Color (1, 0.31f, 0.31f, 1);
		Cloud2.color = new Color (1, 0.31f, 0.31f, 1);
		Light1.color = new Color (0.31f, 1, 1, 1);
		Light2.color = new Color (0.31f, 1, 1, 1);
		Light3.color = new Color (0.31f, 1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
