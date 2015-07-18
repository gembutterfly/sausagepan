using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerController : MonoBehaviour {

	// Player textures
	public List<GameObject> playerTextures = new List<GameObject> ();

	public float maxSpeed = 4;									// Speed of Player
	public float pushPower = -550;								// A push power that will influence the player
	public float jumpForce = 550;								// A variable for players jump power
	public Transform groundCheck;								// A Gizmo variable
	public LayerMask whatIsGround;								

	[HideInInspector] 											// invisible in Unity GUI
	public List<Color> foundColors = new List<Color> ();		// A List that will be filled with all found colors in game

	[HideInInspector]											// invisible in Unity GUI
	public bool lookingRight = true;							// A bool variable for the looking direction of player

	private Rigidbody2D char2D;
	private Animator anim;
	private bool isGrounded = false;
	private bool jump = false;
	private Color oldColor;										// A variable for the currently player color
	private Color mixColor;										// Result color between the combination of two colors
	private Color mix;											// Result of the additive or subtractive painting
	private UIBottomManager uIBottomManager;

	/**
	 * Flip the looking direction of player
	 **/
	public void Flip() 
	{
		lookingRight = !lookingRight;

		// scale x by -1 to flip coordinate system
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

	/**
	 * Paints the character according to its recent color.
	 * true = additive color mixing
	 * false = subtractive color mixing
	 * */
	public void PaintChar(Color newColor, bool additive)
	{
		oldColor = playerTextures [0].GetComponent<SpriteRenderer> ().color;	// Get old color of figure
		
		// Determine mixed color
		if (additive)											
			mixColor = MixColorsAdditive (oldColor, newColor);
		else
			mixColor = MixColorsSubtractive(oldColor, newColor);

		FoundNewColor (newColor);								// Call a function that will check the new collected color and maybe it will be added to foundColors							
		FoundNewColor (mixColor);								// Call a function that will check the new mixed color and maybe it will be added to foundColors


		for (int i = 0; i < playerTextures.Count; i++) 
		{
			playerTextures[i].GetComponent<SpriteRenderer>().color = mixColor;
		}
	}
	
	/**
	 * Subtractive painting
	 **/
	public Color MixColorsSubtractive(Color col1, Color col2) 
	{
		if (col2.Equals (Color.white)) 
		{
			mix = col2;
		}
		else 
		{
			float r = col1.r - (1 - col2.r);
			float g = col1.g - (1 - col2.g);
			float b = col1.b - (1 - col2.b);

			r = Mathf.Min (Mathf.Max (r, 0), 1);
			g = Mathf.Min (Mathf.Max (g, 0), 1);
			b = Mathf.Min (Mathf.Max (b, 0), 1);

//		Debug.Log (r);
//		Debug.Log (g);
//		Debug.Log (b);

			mix = new Color (r, g, b, 1);
		}

		return mix;
	}

	/**
	 * Additive painting
	 **/
	public Color MixColorsAdditive(Color oldColor, Color newColor)
	{
		float r = oldColor.r + newColor.r;
		float g = oldColor.g + newColor.g;
		float b = oldColor.b + newColor.b;
		
		r = Mathf.Min (1, r);
		g = Mathf.Min (1, g);
		b = Mathf.Min (1, b);

		mix = new Color (r, g, b, 1);

		return mix;
	}

	/**
	 * Push player back
	 **/
	public void PushBackPlayer()
	{
		if (lookingRight) {
			char2D.AddForce (new Vector2 (pushPower * 1000 * Time.deltaTime, 0));
		} else {
			char2D.AddForce (new Vector2 ((-1) * pushPower * 1000 * Time.deltaTime, 0));
		}
	}

	/**
	 * Convert a color to their complementary color and set it on the colorMoth1Comp variable
	 * */
	public bool FindComplementaryColor(Color enemyColor)
	{
		Color enemyComplementaryColor = new Color();

		// Red -> Green
		if (enemyColor == new Color (1, 0, 0, 1)) {
			enemyComplementaryColor = new Color (0, 1, 0, 1);
		} 
		
		// Green -> Red
		if (enemyColor == new Color (0, 1, 0, 1)) {
			enemyComplementaryColor = new Color (1, 0, 0, 1);
		} 
		
		// Blue -> Orange
		if (enemyColor == new Color (0, 0, 1, 1)) {
			enemyComplementaryColor = new Color (1, 0.5F, 0, 1);
		} 
		
		// Orange -> Blue
		if (enemyColor == new Color (1, 0.5F, 0, 1)) {
			enemyComplementaryColor = new Color (0, 0, 1, 1);
		} 
		
		// Violet -> Yellow
		if (enemyColor == new Color (0.64F, 0, 0.94F, 1)) {
			enemyComplementaryColor = new Color (1, 1, 0, 1);
		} 
		
		// Yellow -> Violet
		if (enemyColor == new Color (1, 1, 0, 1)) {
			enemyComplementaryColor = new Color (0.64F, 0, 0.94F, 1);
		}

		if (enemyComplementaryColor.Equals (mixColor)) 
		{
			return true;
		} 
		else 
		{
			PushBackPlayer();
			Invoke("PlayerControllerIsAble", 1);
			enabled = false;	

			return false;
		}
	}

	public void CollectingItem()
	{
		anim.SetBool ("collecting", true);

		Invoke ("ResetCollectingItemAnimation", 1);

	}

	void ResetCollectingItemAnimation()
	{
		anim.SetBool ("collecting", false);
	}
	/**
	 * Reset player controller
	 **/
	void PlayerControllerIsAble()
	{
		enabled = true;
	}

	/**
	 * Check and add a new found color to a list
	 * */
	void FoundNewColor(Color foundColor)
	{
		foreach (Color color in foundColors.ToList())
		{
			if(color.Equals(foundColor))
			{
				//Debug.Log("Found " + color);
			} 
			else
			{
				foundColors.Add(foundColor);
				uIBottomManager.InitializeFullColorList ();
				uIBottomManager.FillColorCircle (foundColors);
				//Debug.Log ("New Color " + color);
			}
		}

		List<Color> distinct = foundColors.Distinct().ToList();	// Get distinct elements and convert into a list again.
		foundColors = distinct;
		//Debug.Log ("pre++ " + foundColors.Count);
	}

	// Use this for initialization
	void Start () 
	{
		char2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		uIBottomManager = GameObject.Find ("UIBottomManager").GetComponent<UIBottomManager> ();

		foundColors.Add(new Color(0, 0, 0, 1));					// Initialize first color in foundColors

		uIBottomManager.InitializeFullColorList ();
		uIBottomManager.FillColorCircle (foundColors);
		
		//PaintChar (new Color (0, 1, 1, 1), true);
	}
	
	// Update is called once per frame
	// jumping and firing here
	void Update () {
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			jump = true;
		}
	}
	
	// Update is called indepently from frames
	void FixedUpdate() 
	{
		// get user horizontal input
		float inpx = Input.GetAxis ("Horizontal");

		// set animator parameter
		anim.SetFloat ("speed", Mathf.Abs(inpx));
		
		// set x and y speed of character
		char2D.velocity = new Vector2 (inpx * maxSpeed, char2D.velocity.y);
		
		// checks whether colliders are within a given circle
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);
		
		anim.SetBool ("isGrounded", isGrounded);

		// Set looking direction
		if((inpx > 0 && !lookingRight) || (inpx < 0 && lookingRight)) 
		{
			Flip();
		}
		
		if (jump) 
		{
			char2D.AddForce(new Vector2(0, jumpForce));
			jump = false;
		}
		
	}
}