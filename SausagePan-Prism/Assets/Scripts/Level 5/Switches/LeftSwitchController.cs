using UnityEngine;
using System.Collections;

public class LeftSwitchController : MonoBehaviour {
	
	public Transform prism;
	public float speed = 8;
	public float minValue;
	
	// Use this for initialization
	void Start () {
	}

	void OnMouseDrag()
	{
		if(Input.GetMouseButton(0))
		{
			if(prism.position.x >= minValue)
				prism.position += Vector3.left * speed * Time.deltaTime;
		}
	}

}
