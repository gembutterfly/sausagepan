using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	// Use this for initialization
	void Start ()
	{
		items.Add (new Item ("crystalBLUE", 0, "Blue is nice", Item.ItemType.Quest));
		items.Add (new Item ("crystalRED", 1, "Red is nice", Item.ItemType.Quest));
		items.Add (new Item ("crystalORANGE", 2, "Orange is nice", Item.ItemType.Quest));
		items.Add (new Item ("crystalYELLOW", 3, "Yellow is nice", Item.ItemType.Quest));
		items.Add (new Item ("crystalGREEN", 4, "Green is nice", Item.ItemType.Quest));
		items.Add (new Item ("crystalMAGENTA", 5, "Magenta is nice", Item.ItemType.Quest));
		items.Add (new Item ("crystalCYAN", 6, "Cyan is nice", Item.ItemType.Quest));
		items.Add (new Item ("", 7, "", Item.ItemType.Quest));
	}

}
