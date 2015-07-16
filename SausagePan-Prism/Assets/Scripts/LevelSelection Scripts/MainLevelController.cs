using UnityEngine;
using System.Collections;

public class MainLevelController : MonoBehaviour {

	public string levelName;
	public GameObject grayTextures;
	public GameObject colorTextures;
	public int levelNumber;

	private GameManager gameManager;
	public Inventory inventory;
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
			if(gameManager.getLevelValue (levelNumber - 1))
			{
				if(levelNumber == 6)
				{
					foreach(Item item in inventory.inventory)
					{
						Debug.Log (item.itemID);
						Debug.Log (item.itemName);
					}

					//Debug.Log ("enter new second");
					//Debug.Log (inventory.inventory [1].itemName.Equals ("orange_crystal"));
					//Debug.Log(inventory.inventory [6].itemName.Equals ("magenta_crystal"));
					/*if(inventory.inventory[2].itemName.Equals("orange_crystal") && inventory.inventory [5].itemName.Equals ("magenta_crystal"))
						Application.LoadLevel ("szene5");
					else
						return;*/
				}
				else
					Application.LoadLevel(levelName);
			}
			else
				return;

		}
	}
	

}
