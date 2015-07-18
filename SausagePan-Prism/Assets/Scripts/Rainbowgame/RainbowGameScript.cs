using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RainbowGameScript : MonoBehaviour {

	public GameObject excl;
	public GameObject light_full;
	public GameObject mothBubble;
	public GameObject help;

	private Inventory inventory;

	// Use this for initialization
	void Start () 
	{
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

		inventory.LoadInventory ();

		excl.SetActive(true);
		light_full.SetActive(false);
		mothBubble.SetActive (false);
		inventory.showInventory = true;

		Invoke("Evidence", 10);
		Invoke ("Check1", 10);
	}

	public void ShowHelp()
	{
		help.SetActive (true);
		inventory.showInventory = false;
	}

	public void HideHelp()
	{
		help.SetActive (false);
		inventory.showInventory = true;
	}

	void ResetMothBubble()
	{
		mothBubble.SetActive (false);

		Invoke("Evidence", 20);
	}

	void next()
	{
		StartCoroutine ("ChangeLevel");
	}

	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("UIManager").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		
		Application.LoadLevel ("Outro1");
	}

	void Check1()
	{
		bool invenotryNotNull = false;

		for (int i = 0; i < inventory.inventory.Count; i++) 
		{
			if (inventory.inventory [i].itemName != null) 
				invenotryNotNull = true;
			else
				invenotryNotNull = false;
		}

		if (invenotryNotNull) 
		{
			if (inventory.inventory [0].itemName.Equals ("red_crystal") &&
				inventory.inventory [1].itemName.Equals ("orange_crystal") &&
				inventory.inventory [2].itemName.Equals ("yellow_crystal") &&
				inventory.inventory [3].itemName.Equals ("green_crystal") &&
				inventory.inventory [4].itemName.Equals ("cyan_crystal") &&
				inventory.inventory [5].itemName.Equals ("blue_crystal") &&
				inventory.inventory [6].itemName.Equals ("violet_crystal")) 
			{
				excl.SetActive (false);
				light_full.SetActive (true);
				inventory.showInventory = false;
				Invoke ("next", 2);
				
			} else {
				Invoke ("Check2", 2);
			}
		}
	}

	void Check2 ()
	{
		Invoke ("Check1", 1);
	}

	void Evidence()
	{
		mothBubble.SetActive (true);
		Invoke("ResetMothBubble", 10);
	}
}
