using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;	// Textur that will overlay the screen
	public float fadeSpeed = 0.1f;		// The fading speed

	private int drawDeph = -1000;		// Drawing hierarchy: a low number means it renders on top
	private float alpha = 1.0f; 		// Texture alpha
	private int fadeDir = -1; 			// The direction to fade: in = -1 or out = 1
	private Inventory inventory;
	private UIBottomManager uIBottomManager;

	/**
	 * Set fadeDir to the direction parameter making the scene fade in if -1 and out if 1
	 * */
	public float BeginFade(int direction)
	{
		if (direction == 1) 
		{
			inventory.SaveInventory ();

			if (!Application.loadedLevelName.Equals ("Rainbowgame") || Application.loadedLevelName.Equals ("LevelSelection")) 
				uIBottomManager.SaveColorList();
		}

		fadeDir = direction;
		return (fadeSpeed); 
	}

	void OnGUI()
	{
		// Fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		// Force (clamp) the number between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		// Set color of GUI
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);				// Set alpha value
		GUI.depth = drawDeph;																// Make sure that the texture will draw last
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);		// Draw texture over the full screen
	}

	/**
	 * OnLevelWasLoaded is called when a level is loaded.
	 * It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes
	 * */
	void OnLevelWasLoaded()
	{
		BeginFade (-1);	// Call the fade in function
	}

	void Start()
	{
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

		if (!Application.loadedLevelName.Equals ("Rainbowgame") || Application.loadedLevelName.Equals ("LevelSelection")) 
			uIBottomManager = GameObject.Find ("UIBottomManager").GetComponent<UIBottomManager> ();
	}
}
