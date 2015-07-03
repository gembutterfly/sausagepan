using UnityEngine;
using System.Collections;

public class MainLevelController : MonoBehaviour {

	public string levelName;
	public GameObject grayTextures;
	public GameObject colorTextures;
	public int levelNumber;
	private GameManager gameManager;
	public SpriteRenderer nextPosition;
	// Use this for initialization
	void Start () {
		colorTextures.SetActive (false);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		nextPosition.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gameManager.getLevelValue (levelNumber)) {
			grayTextures.SetActive(false);
			colorTextures.SetActive(true);
			nextPosition.enabled = true;
		}
		
	}

	void OnMouseDown()
	{
		if (Input.GetMouseButtonDown (0)) {
			if(gameManager.getLevelValue (levelNumber -1))
			{
				Application.LoadLevel(levelName);
			}
			else
				return;

		}
	}
	

}
