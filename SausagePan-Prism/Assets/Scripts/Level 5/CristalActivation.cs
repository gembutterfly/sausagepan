using UnityEngine;
using System.Collections;

public class CristalActivation : MonoBehaviour {

	private bool isTouched = false;
	public Collider2D littleGuy;

	public string colorRayName;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (GetComponent<Collider2D> (), littleGuy);
	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreCollision (GetComponent<Collider2D> (), littleGuy);
	}

	public bool getTouched()
	{
		return isTouched;
	}

	void OnTriggerEnter2D(Collider2D ray)
	{
		if(ray.CompareTag (colorRayName))
			isTouched = true;
	}

	void OnTriggerExit2D(Collider2D ray)
	{
		if (ray.CompareTag (colorRayName))
			isTouched = false;
	}
}
