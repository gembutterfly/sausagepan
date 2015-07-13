using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RainbowGameScript : MonoBehaviour {

	public GameObject excl;
	public GameObject light_full;
	public GameObject button;
	public GameObject mothBubble;
	public GameObject help;

	private Inventory inventory;

	// Use this for initialization
	void Start () 
	{
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

		excl.SetActive(true);
		button.SetActive(true);
		light_full.SetActive(false);
		mothBubble.SetActive (false);
		inventory.showInventory = true;
	}
	
	public void CheckColors()
	{
		if (inventory.inventory [0].itemName.Equals ("red_crystal") &&
			inventory.inventory [1].itemName.Equals ("orange_crystal") &&
			inventory.inventory [2].itemName.Equals ("yellow_crystal") &&
			inventory.inventory [3].itemName.Equals ("green_crystal") &&
			inventory.inventory [4].itemName.Equals ("cyan_crystal") &&
			inventory.inventory [5].itemName.Equals ("blue_crystal") &&
			inventory.inventory [6].itemName.Equals ("magenta_crystal")) 
		{
			excl.SetActive (false);
			button.SetActive (false);
			light_full.SetActive (true);
			inventory.showInventory = false;

		} else 
		{
			mothBubble.SetActive (true);
			Invoke("ResetMothBubble", 3);
		}
	}

	public void ShowHelp()
	{
		help.SetActive (true);
	}

	public void HideHelp()
	{
		help.SetActive (false);
	}

	void ResetMothBubble()
	{
		mothBubble.SetActive (false);
	}
}
