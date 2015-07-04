using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class ButtonScript : MonoBehaviour, IPointerDownHandler {

	public Image mothWing1;					// Image of moths wing
	public Image mothWing2;					// Image of moths wing
	public Image mothBody;					// Image of moths body
	public string buttonColor;				// String (color) of a button
	
	private Color color;

	public void OnPointerDown(PointerEventData data)
	{
		GetColor (buttonColor);				// Call a function that will convert string (color) into Color
		ColorMoth ();						// Call a function that will paint moth with the chosen color
	}

	/**
	 * Convert (string) color to Color
	 * */
	void GetColor(string btnColor)
	{
		switch (btnColor) 
		{
			case "blue": 
				color = new Color(0, 0, 1, 1);
				break;
			case "red": 
				color = new Color(1, 0, 0, 1); 
				break;
			case "white": 
				color = new Color(1, 1, 1, 1); 
				break;
			case "yellow": 
				color = new Color(1, 1, 0, 1); 
				break;
			case "green": 
				color = new Color(0, 1, 0, 1); 
				break;
			case "violet": 
				color = new Color(0.64F, 0, 0.94F, 1);
				break;
			case "cyan": 
				color = new Color(0, 1, 1, 1);
				break;
			case "black":
				color = new Color(0, 0, 0, 1);
				break;
			case "orange":
				color = new Color(1, 0.5F, 0, 1);
				break;
			case "blueblue":
				color = new Color(0, 0.5F, 1, 1);
				break;
			default: 
				color = new Color(1, 1, 1, 1); 
				break;
		}
	}

	/**
	 * Paint moth with a color
	 * */
	void ColorMoth()
	{
		mothWing1.color = color;
		mothWing2.color = color;
		mothBody.color = color;
	}

	void Start()
	{
		// Set a default color (white) of moth
		mothWing1.color = new Color(1, 1, 1, 1);
		mothWing2.color = new Color(1, 1, 1, 1);
		mothBody.color = new Color(1, 1, 1, 1);
	}
}
