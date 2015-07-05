using UnityEngine;
using System.Collections;

public class TestFinishScene : MonoBehaviour {

	public Collider2D bodyCollider;
	private Collider2D doorCollider;

	public GameManager manager;
	public int levelNumber;
	// Use this for initialization
	void Start () {
		doorCollider = GetComponent<Collider2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (doorCollider.IsTouching (bodyCollider)) {
			manager.setCounter(levelNumber);
			manager.changeLevelValue(levelNumber);

			Application.LoadLevel("LevelSelection");
		}
	
	}
	
}
