using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	// Use this for initialization
	void Start ()
	{
		items.Add (new Item ("crystal", 0, "Blue is nice", Item.ItemType.Quest));
		items.Add (new Item ("0EpSU", 1, "Red is nice", Item.ItemType.Quest));
		items.Add (new Item ("2A7vi", 2, "Green is nice", Item.ItemType.Quest));
	}

}
