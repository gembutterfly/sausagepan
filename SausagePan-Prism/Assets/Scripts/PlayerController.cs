using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 4;
	public float pushPower = -550;
	public float jumpForce = 550;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	private Rigidbody2D char2D;
	private Animator anim;
	[HideInInspector] // invisible in Unity GUI
	public bool lookingRight = true;
	private bool isGrounded = false;
	private bool jump = false;
	private Color oldColor;
	private Color mixColor;
	private Color mix;


	// Use this for initialization
	void Start () {
		char2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
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

	public void Flip() {
		lookingRight = !lookingRight;
		// scale x by -1 to flip coordinate system
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

	public void PaintChar(Color newColor)
	{
		GameObject bodypart = GameObject.Find ("blackBuddy/textures/head/head_side");
		SpriteRenderer sprite = bodypart.GetComponent<SpriteRenderer> ();

		// Get old color of figure
		oldColor = sprite.color;
		
		// determine mixed color
		mixColor = MixColors (oldColor, newColor);

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

	public Color MixColors(Color oldColor, Color newColor)
	{
		// Determine first color
		if (oldColor.Equals (Color.white) || oldColor.Equals (Color.black)) {
			mix = newColor;
		}

		if (oldColor.Equals(newColor)) {		
			mix = oldColor;		
		}

		// He was magenta
		if (oldColor.Equals (Color.magenta)) 
		{
			if (newColor.Equals(Color.blue)){
				mix = Color.magenta;
			}

			if (newColor.Equals(Color.green)){
				// Right color is gray
				mix = Color.black;
			}

			if (newColor.Equals(Color.yellow)){
				// Right color is orange
				mix = Color.red;
			}

			if (newColor.Equals(Color.red)){
				// Right color is purple
				mix = Color.red;
			}
		}

		// He was blue
		if (oldColor.Equals (Color.blue)) 
		{
			if (newColor.Equals(Color.magenta)){
				mix = Color.magenta;
			}

			if (newColor.Equals(Color.green)){
				mix = Color.green;
			}

			if (newColor.Equals(Color.yellow)){
				mix = Color.green;
			}

			if (newColor.Equals(Color.red)){
				// Right color is purple
				mix = Color.magenta;
			}
		}

		// He was green
		if (oldColor.Equals (Color.green)) 
		{
			if (newColor.Equals(Color.magenta)){
				// Right color is gray
				mix = Color.black;
			}

			if (newColor.Equals(Color.blue)){
				mix = Color.green;
			}

			if (newColor.Equals(Color.yellow)){
				mix = Color.green;
			}

			if (newColor.Equals(Color.red)){
				// Right color is brown
				mix = Color.green;
			}
		}

		// He was yellow
		if (oldColor.Equals (Color.yellow)) 
		{
			if (newColor.Equals(Color.magenta)){
				// Right color is brown
				mix = Color.yellow;
			}
			
			if (newColor.Equals(Color.blue)){
				mix = Color.green;
			}
			
			if (newColor.Equals(Color.green)){
				mix = Color.green;
			}
			
			if (newColor.Equals(Color.red)){
				// Right color is orange
				mix = Color.yellow;
			}
		}

		// He was red
		if (oldColor.Equals (Color.red)) 
		{
			if (newColor.Equals(Color.magenta)){
				// Right color is purple
				mix = Color.magenta;
			}

			if (newColor.Equals(Color.blue)){
				mix = Color.magenta;
			}

			if (newColor.Equals(Color.green)){
				// Right color is brown
				mix = Color.red;
			}

			if (newColor.Equals(Color.yellow)){
				// Right color is orange
				mix = Color.yellow;
			}
		}

		return mix;

	}

	public void PushBackPlayer()
	{
		char2D.AddForce(char2D.velocity * pushPower);
	}
}
