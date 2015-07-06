using UnityEngine;
using System.Collections;

public class GodRay : MonoBehaviour {

	public string rayColor;

	private Color color;
	private PlayerController playerController;

	public void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
	}


	public void ColorPlayer(Color lightColor)
	{
		playerController.PaintChar(lightColor, true);
	}

	// Start event on collision
	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			ColorPlayer(LightColor());
		}

	}

	// Return color of godray
	Color LightColor()
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
		case "cyan":
			color = Color.cyan;
			break;
		default: 
			color = Color.black;
			break;
		}
		
		return color;
	}
}
