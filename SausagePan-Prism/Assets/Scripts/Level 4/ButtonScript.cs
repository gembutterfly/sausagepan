using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class ButtonScript : MonoBehaviour, IPointerDownHandler {

	public Image mothWing1;
	public Image mothWing2;
	public Image mothBody;
	public string buttonColor;
	
	private Color color;

	public void OnPointerDown(PointerEventData data)
	{
		GetColor (buttonColor);
		ColorMoth ();
	}

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

	void ColorMoth()
	{
		mothWing1.color = color;
		mothWing2.color = color;
		mothBody.color = color;
	}

	void Start()
	{
		mothWing1.color = new Color(1, 1, 1, 1);
		mothWing2.color = new Color(1, 1, 1, 1);
		mothBody.color = new Color(1, 1, 1, 1);
	}
}
