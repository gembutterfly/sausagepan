using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 4;
	public float pushPower = -550;
	public float jumpForce = 550;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	[HideInInspector] // invisible in Unity GUI
	public List<Color> foundColors = new List<Color> ();

	[HideInInspector] // invisible in Unity GUI
	public bool lookingRight = true;

	private Rigidbody2D char2D;
	private Animator anim;
	private bool isGrounded = false;
	private bool jump = false;
	private Color oldColor;
	private Color mixColor;
	private Color mix;
	private UIBottomManager uIBottomManager;

	public void Flip() {
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
		GameObject bodypart = GameObject.Find ("blackBuddy/textures/head/head_side");
		SpriteRenderer sprite = bodypart.GetComponent<SpriteRenderer> ();

		// Get old color of figure
		oldColor = sprite.color;
		
		// determine mixed color
		if (additive)
			mixColor = MixColorsAdditive (oldColor, newColor);
		else
			mixColor = MixColorsSubtractive(oldColor, newColor);

		/**
		 * Check and add a new found color to a list
		 * */
		FoundNewColor (mixColor);

		sprite.color = mixColor;

		bodypart = GameObject.Find ("blackBuddy/textures/body");
		sprite = bodypart.GetComponent<SpriteRenderer> ();
		sprite.color = mixColor;
		
		bodypart = GameObject.Find ("blackBuddy/textures/foot_back");
		sprite = bodypart.GetComponent<SpriteRenderer> ();
		sprite.color = mixColor;
		
		bodypart = GameObject.Find ("blackBuddy/textures/foot_front");
		sprite = bodypart.GetComponent<SpriteRenderer> ();
		sprite.color = mixColor;
	}
	

	public Color MixColorsSubtractive(Color col1, Color col2) {
		
		if (col2.Equals (Color.white)) 
		{
			mix = col2;
		}
		else {
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

//		Color mix = Color.black;
//		
//		// determine first color
//		if (col1.Equals (Color.white) || col1.Equals (Color.black)) {
//			mix = col2;
//		}
//		// he was blue
//		if(col1.Equals (Color.blue)) {
//			if(col2.Equals(Color.yellow)) {
//				mix = Color.black;
//			}
//		}
//		// he was green
//		if(col1.Equals (Color.green)) {
//			if(col2.Equals(Color.green)) {
//				mix = Color.green;
//			}
//			if(col2.Equals(Color.magenta)) {
//				mix = new Color(Color.green.r-Color.magenta.r,Color.green.g-Color.magenta.g, Color.green.b-Color.magenta.b,1);
//			}
//		}
//		
//		// he was magenta
//		if(col1.Equals (Color.magenta)) {
//			if(col2.Equals(Color.green)) {
//				mix = Color.black;
//			}
//			if(col2.Equals(Color.magenta)) {
//				mix = Color.magenta;
//			}
//		}
	}

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

	public void PushBackPlayer()
	{
		int new_x_position = (int)(0.01f * char2D.position.x * pushPower);
		int new_y_position = 0;

		char2D.AddForce(new Vector2(new_x_position, new_y_position), ForceMode2D.Impulse);
	}

	/**
	 * 
	 * */
	public bool DamageCheckRGB(string enemyColor) 
	{
		Color comp;

		switch (enemyColor) 
		{
			case "magenta": 
				comp = Color.yellow;
				break;
			case "green":
				comp = Color.red;
				break;
			case "yellow":
				comp = Color.magenta;
				break;
			case "Red":
				comp = Color.green;
				break;
			case "white":
				comp = Color.black;
				break;
			case "black":
				comp = Color.white;
				break;
			default:
				comp = Color.black;
				break;
		}

//		Debug.Log ("Recent color: " + mix);
//		Debug.Log ("Complementary: " + comp);
//		Debug.Log ("Enemy: " + enemyColor);

		if (comp.Equals (mix)) 
		{
			/* object destroyed */
			return true;
		}
		else 
		{
			/* object not destroyed */
			PushBackPlayer();
			enabled = false;	
			Invoke("PlayerControllerIsAble", 2);
			return false;
		}
	}

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
				uIBottomManager.InitializeFullColorList (foundColors);
				//Debug.Log ("New Color " + color);
			}
		}

		// Get distinct elements and convert into a list again.
		List<Color> distinct = foundColors.Distinct().ToList();
		foundColors = distinct;
		//Debug.Log ("pre++ " + foundColors.Count);
	}

	// Use this for initialization
	void Start () {
		char2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		uIBottomManager = GameObject.Find ("UIBottomManager").GetComponent<UIBottomManager> ();

		foundColors.Add(new Color(0.5F, 0.5F, 0.5F, 1));
		foundColors.Add(new Color(0, 0, 0, 1));

		uIBottomManager.InitializeFullColorList (foundColors);
	}
	
	// Update is called once per frame
	// jumping and firing here
	void Update () {
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			jump = true;
		}
	}
	
	// Update is called indepently from frames
	void FixedUpdate() {
		// get user horizontal input
		float inpx = Input.GetAxis ("Horizontal");
		// set animator parameter
		anim.SetFloat ("speed", Mathf.Abs(inpx));
		
		// set x and y speed of character
		char2D.velocity = new Vector2 (inpx * maxSpeed, char2D.velocity.y);
		
		// checks whether colliders are within a given circle
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);
		
		anim.SetBool ("isGrounded", isGrounded);
		
		if((inpx > 0 && !lookingRight) || (inpx < 0 && lookingRight)) {
			Flip();
		}
		
		if (jump) {
			char2D.AddForce(new Vector2(0, jumpForce));
			jump = false;
		}
		
	}
}
