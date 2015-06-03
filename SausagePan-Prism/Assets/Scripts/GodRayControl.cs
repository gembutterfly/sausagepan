using UnityEngine;
using System.Collections;

public class GodRayControl : MonoBehaviour {

	private PlayerController playerController;

	public void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
	}

	public void Awake()
	{
		GodRayColorEvent.onColorPlayer += this.ColorPlayer;
	}

	public void ColorPlayer(Color lightColor)
	{
		playerController.PaintChar(lightColor, true);
	}
}
