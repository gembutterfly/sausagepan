using UnityEngine;
using System.Collections;

public class ColorEvent : MonoBehaviour {

	private SpriteRenderer[] littleGuy = new SpriteRenderer[6];
	private Color myYellow;
	// Use this for initialization
	void Start () {
		littleGuy[0] = GameObject.Find ("Little Guy/Textures/Head").GetComponent<SpriteRenderer> ();
		littleGuy[1] = GameObject.Find ("Little Guy/Textures/Body").GetComponent<SpriteRenderer> ();
		littleGuy [2] = GameObject.Find ("Little Guy/Textures/Left Arm").GetComponent<SpriteRenderer> ();
		littleGuy [3] = GameObject.Find ("Little Guy/Textures/Right Arm").GetComponent<SpriteRenderer> ();
		littleGuy [4] = GameObject.Find ("Little Guy/Textures/Left Leg").GetComponent<SpriteRenderer> ();
		littleGuy [5] = GameObject.Find ("Little Guy/Textures/Right Leg").GetComponent<SpriteRenderer> ();

		changeColor (Color.black);

		myYellow = new Color (1, 1, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D colorObject)
	{
		if(colorObject.CompareTag("Blue"))
		   addColor(Color.blue);

		if(colorObject.CompareTag ("Red"))
			addColor (Color.red);

		if(colorObject.CompareTag ("Green"))
			addColor (Color.green);

		if(colorObject.CompareTag ("White"))
			changeColor (Color.white);

		if(colorObject.CompareTag ("Cyan"))
			addColor (Color.cyan);

		if(colorObject.CompareTag ("Magenta"))
			addColor (Color.magenta);

		if(colorObject.CompareTag("Yellow"))
			addColor(myYellow);
	}
	

	void changeColor(Color color)
	{
		for (int x = 0; x < 6; x++) {
			littleGuy[x].color = color;
		}
	}

	void addColor(Color color)
	{
		for (int x = 0; x < 6; x++) {
			if(littleGuy[x].color.Equals(Color.black))
				littleGuy[x].color = Color.clear;

			littleGuy[x].color = littleGuy[x].color + color;
		}
		checkColor ();
	}

	void checkColor()
	{
		Color myColor = littleGuy [0].color;

		if (myColor.a < 0)
			myColor.a = 0;

		if (myColor.a > 1)
			myColor.a = 1;

		if (myColor.r < 0)
			myColor.r = 0;
		
		if (myColor.r > 1)
			myColor.r = 1;

		if (myColor.g < 0)
			myColor.g= 0;
		
		if (myColor.g > 1)
			myColor.g = 1;

		if (myColor.b < 0)
			myColor.b= 0;
		
		if (myColor.b > 1)
			myColor.b = 1;

		for (int x = 0; x < 6; x++) {
			littleGuy[x].color = myColor;
		}
	}
	
}
