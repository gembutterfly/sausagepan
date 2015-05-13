using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 4;
	public float jumpForce = 550;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	private Rigidbody2D char2D;
	private Animator anim;
	[HideInInspector] // invisible in Unity GUI
	public bool lookingRight = true;
	private bool isGrounded = false;
	private bool jump = false;


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
	
}
