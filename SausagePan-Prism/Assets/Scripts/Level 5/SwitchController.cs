using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {
	
	private Collider2D switchCollider;

	public Transform prism;
	public Collider2D littleGuy;
	public float speed = 8;

	// Use this for initialization
	void Start () {
		switchCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (switchCollider.IsTouching (littleGuy)) 
		{
			Debug.Log("Touching collision");
			if(Input.GetKey(KeyCode.R))
			{
				prism.position += Vector3.right * speed * Time.deltaTime;
				Debug.Log ("Enter right");
			}

			if(Input.GetKey(KeyCode.L))
			{
				prism.position += Vector3.left * speed * Time.deltaTime;
				Debug.Log("Enter left");
			}
		}
	}
	
}
