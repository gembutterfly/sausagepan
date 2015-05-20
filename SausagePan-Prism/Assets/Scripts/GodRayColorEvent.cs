using UnityEngine;
using System.Collections;

public class GodRayColorEvent : MonoBehaviour {

	public string rayName;
	public bool stayInColor = false;

	public delegate void ColorHandler(Color lightColor);
	
	public static event ColorHandler onColorPlayer;


	private Color rayColor;

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
		switch (rayName) 
		{
			case "godray_blue":
				rayColor = Color.blue; 
				break;
			case "godray_red": 
				rayColor = Color.red; 
				break;
			case "godray_white": 
				rayColor = Color.white; 
				break;
			case "godray_yellow": 
				rayColor = Color.yellow; 
				break;
			case "godray_green": 
				rayColor = Color.green; 
				break;
			case "godray_magenta": 
				rayColor = Color.magenta; 
				break;
			default: 
				rayColor = Color.black;
				break;
		}

		return rayColor;
	}

	public void Update()
	{
		// Find and set the name of godrays
		SpriteRenderer godRay = GetComponent<SpriteRenderer> ();
		rayName = godRay.name;

	}
}
