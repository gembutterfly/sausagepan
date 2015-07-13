using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	// Use this for initialization
	void Start ()
	{
		items.Add (new Item ("blue_crystal", 0, "Blue is nice", Item.ItemType.Quest));
		items.Add (new Item ("red_crystal", 1, "Red is nice", Item.ItemType.Quest));
		items.Add (new Item ("orange_crystal", 2, "Orange is nice", Item.ItemType.Quest));
		items.Add (new Item ("yellow_crystal", 3, "Yellow is nice", Item.ItemType.Quest));
		items.Add (new Item ("green_crystal", 4, "Green is nice", Item.ItemType.Quest));
		items.Add (new Item ("magenta_crystal", 5, "Magenta is nice", Item.ItemType.Quest));
		items.Add (new Item ("cyan_crystal", 6, "Cyan is nice", Item.ItemType.Quest));
		items.Add (new Item ("", 7, "", Item.ItemType.Quest));
	}

}
