using UnityEngine;
using System.Collections;

public class GMScript : MonoBehaviour {

	private Inventory inventory;
	private GameManager gameManager;

	// Use this for initialization
	void Start () 
	{
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("GMCode")) 
		{
			for (int i = 0; i < 7; i++)
			{
				inventory.AddItem(i);
				gameManager.changeLevelValue(i);

			}

			inventory.SaveInventory();
		}
	}
}
