using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldController : MonoBehaviour {

	public List<GameObject> greyTextures = new List<GameObject>();
	public List<GameObject> colorTextures = new List<GameObject>();
	public List<SpriteRenderer> pathPoints = new List<SpriteRenderer>();
	public List<Transform> pathPositions = new List<Transform>();

	private Inventory inventory;
	private GameObject player;


	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		player = GameObject.FindGameObjectWithTag ("Player");

//		inventory.AddItem (0);
//		inventory.AddItem (3);
//		inventory.AddItem (1);
//		inventory.AddItem (4);
//		inventory.AddItem (6);
//		inventory.AddItem (2);
//		inventory.AddItem (5);

		inventory.LoadInventory ();

		for (int x=0; x < colorTextures.Count; x++) 
		{
			colorTextures[x].SetActive(false);
		}

		for (int x=0; x < pathPoints.Count; x++) 
		{
			pathPoints[x].enabled = false;
		}

		paintWorld ();
	}
	
	void paintWorld()
	{
		int counter = 0;
		for (int x=0; x < inventory.inventory.Count; x++) 
		{
			if(inventory.inventory[x].itemName != null)
			{
				if(inventory.inventory[x].itemName.Equals("blue_crystal"))
				{
					colorTextures[0].SetActive(true);
					greyTextures[0].SetActive(false);
					pathPoints[0].enabled = true;
					counter++;
				}

				if(inventory.inventory[x].itemName.Equals("yellow_crystal"))
				{
					colorTextures[1].SetActive(true);
					greyTextures[1].SetActive(false);
					pathPoints[0].enabled = false;
					pathPoints[1].enabled = true;
					counter++;
				}

				if(inventory.inventory[x].itemName.Equals("red_crystal"))
				{
					colorTextures[2].SetActive(true);
					greyTextures[2].SetActive(false);
					pathPoints[1].enabled = false;
					pathPoints[2].enabled = true;
					counter++;
				}

				if(inventory.inventory[x].itemName.Equals("green_crystal"))
				{
					colorTextures[3].SetActive(true);
					greyTextures[3].SetActive(false);
					pathPoints[2].enabled = false;
					pathPoints[3].enabled = true;
					counter++;
				}

				if(inventory.inventory[x].itemName.Equals("cyan_crystal"))
				{
					colorTextures[4].SetActive(true);
					greyTextures[4].SetActive(false);
					pathPoints[3].enabled = false;
					pathPoints[4].enabled = true;
					counter++;
				}

				if(inventory.inventory[x].itemName.Equals("orange_crystal"))
				{
					colorTextures[5].SetActive(true);
					greyTextures[5].SetActive(false);
				}

				if(inventory.inventory[x].itemName.Equals("orange_crystal"))
				{
					colorTextures[6].SetActive(true);
					greyTextures[6].SetActive(false);
				}
			}
		}

		switch (counter) 
		{
		case 0: player.gameObject.GetComponent<Transform>().localPosition = new Vector3(pathPositions[0].transform.localPosition.x, pathPositions[0].transform.localPosition.y, 0); break;
		case 1: player.gameObject.GetComponent<Transform>().localPosition = new Vector3(pathPositions[1].transform.localPosition.x, pathPositions[1].transform.localPosition.y, 0); break;
		case 2: player.gameObject.GetComponent<Transform>().localPosition = new Vector3(pathPositions[2].transform.localPosition.x, pathPositions[2].transform.localPosition.y, 0); break;
		case 3: player.gameObject.GetComponent<Transform>().localPosition = new Vector3(pathPositions[3].transform.localPosition.x, pathPositions[3].transform.localPosition.y, 0); break;
		case 4: player.gameObject.GetComponent<Transform>().localPosition = new Vector3(pathPositions[4].transform.localPosition.x, pathPositions[4].transform.localPosition.y, 0); break;
		case 5: player.gameObject.GetComponent<Transform>().localPosition = new Vector3(pathPositions[5].transform.localPosition.x, pathPositions[5].transform.localPosition.y, 0); break;
		}

	}

}