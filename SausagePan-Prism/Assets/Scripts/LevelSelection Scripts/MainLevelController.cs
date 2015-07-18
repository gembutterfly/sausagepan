using UnityEngine;
using System.Collections;

public class MainLevelController : MonoBehaviour {

	public string levelName;
	public int levelNumber;

	private GameManager gameManager;
	private Inventory inventory;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
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
						Application.LoadLevel (levelName);
					else return;
				}

				Application.LoadLevel (levelName);
			}

		}
	}
	

}
