using UnityEngine;
using System.Collections;

public class RightSwitchController : MonoBehaviour {


	public Transform prism;
	public float speed = 8;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnMouseDrag()
	{
		if(Input.GetMouseButton(0))
		{
			prism.position += Vector3.right * speed * Time.deltaTime;
//			Debug.Log ("Enter right");
		}
	}

}
