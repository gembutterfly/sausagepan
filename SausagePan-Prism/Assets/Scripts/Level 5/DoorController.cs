using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	private Transform heavyDoor;
	private Vector3 target;

	public CristalActivation redCristal;
	public CristalActivation blueCristal;
	public CristalActivation greenCristal; 

	public float speed = 10;
	// Use this for initialization
	void Start () {
		heavyDoor = GetComponent<Transform> ();

		target = new Vector3 (heavyDoor.position.x, 23, heavyDoor.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (redCristal.getTouched() && blueCristal.getTouched() && greenCristal.getTouched()) 
		{
			float step = speed * Time.deltaTime;
			heavyDoor.position = Vector3.MoveTowards(heavyDoor.position, target, step);
		}
	
	}
}
