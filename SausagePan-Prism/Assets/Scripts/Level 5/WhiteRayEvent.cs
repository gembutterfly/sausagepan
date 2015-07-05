using UnityEngine;
using System.Collections;

public class WhiteRayEvent : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cutRay(float shortValue)
	{
		Vector3 myScale = transform.localScale;
		myScale.y = shortValue;
		transform.localScale = myScale;
	}

	public void resizeRay(float longValue)
	{
		Vector3 myScale = transform.localScale;
		myScale.y = longValue;
		transform.localScale = myScale;
	}
}
