using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainLevelController : MonoBehaviour {

	public string levelName;
	public int levelNumber;

	public GameObject moth;
	private QuizzButton button;

	private GameManager gameManager;
	private Inventory inventory;

	public GameObject whiteLine; 
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		moth.SetActive (false);
		button = GameObject.Find ("Quiz/Quiz-Button").GetComponent<QuizzButton> ();
		whiteLine.SetActive (false);
	}

	void OnMouseEnter()
	{
		whiteLine.SetActive (true);
	}

	void OnMouseOver()
	{
		whiteLine.SetActive (true);
	}

	void OnMouseExit()
	{
		whiteLine.SetActive (false);
	}


	void OnMouseDown()
	{
		if (Input.GetMouseButtonDown (0)) {
			if(gameManager.getLevelValue (levelNumber - 1))
			{
				if(levelNumber == 6)
				{
					int counter = 0;
					for(int x=0; x < inventory.inventory.Count; x++)
					{
						if(inventory.inventory[x].itemName != null)
							counter++;
					}

					Debug.Log ("counter " + counter);

					if(counter == 7)
					{
						moth.SetActive(false);
						Application.LoadLevel (levelName);
					}
					else 
					{
						moth.SetActive(true);
						return;
					}
				}

				Application.LoadLevel (levelName);
			}

		}
	}
}
