using UnityEngine;
using System.Collections;

public class PlayerEvent : MonoBehaviour {

	private static Transform playerTransform;
	private Animator anim;

	public Transform akwTarget;
	public Transform sunTarget;
	public Transform cloudsTarget;
	public Transform woodsTarget;
	public Transform prismTarget;
	public Transform mountainTarget;

	public GameManager manager;

	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		switch (manager.getCounter ()) 
		{
		case 0: playerTransform.position = akwTarget.position; break;
		case 1:	playerTransform.position = sunTarget.position; break;
		case 2: playerTransform.position = cloudsTarget.position; break;
		case 3: playerTransform.position = woodsTarget.position; break;
		case 4: playerTransform.position = prismTarget.position; break;
		case 5: playerTransform.position = mountainTarget.position; break;
		case 6: playerTransform.position = mountainTarget.position; break;
		}

	
	}

}
