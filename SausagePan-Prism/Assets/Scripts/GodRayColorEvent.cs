using UnityEngine;
using System.Collections;

public class GodRayColorEvent : MonoBehaviour {

	public string rayColor;
	private Color color;

	public delegate void ColorHandler(Color lightColor);
	
	public static event ColorHandler onColorPlayer;

	public static void ColorPlayer(Color lightColor)
	{
		if (onColorPlayer != null)
			onColorPlayer (lightColor);
	}

	// Start event on collision
	public void OnTriggerEnter2D (Collider2D other)
	{
		ColorPlayer(LightColor());
	}

	// Return color of godray
	public Color LightColor()
	{
		switch (rayColor) 
		{
			case "blue":
				color = Color.blue; 
				break;
			case "red": 
				color = Color.red; 
				break;
			case "white": 
				color = Color.white; 
				break;
			case "yellow": 
				color = Color.yellow; 
				break;
			case "green": 
				color = Color.green; 
				break;
			case "magenta": 
				color = Color.magenta; 
				break;
			default: 
				color = Color.black;
				break;
		}

		return color;
	}

	public void Update()
	{
		// Find and set the name of godrays
//		SpriteRenderer godRay = GetComponent<SpriteRenderer> ();
//		rayName = godRay.name;

	}
}
