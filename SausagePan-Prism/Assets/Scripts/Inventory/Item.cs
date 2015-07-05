using UnityEngine;
using System.Collections;

public class Item {

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Sprite itemIcon;
	public GameObject itemModel;
	public ItemType itemType;

	public enum ItemType
	{
		Quest
	}

	public Item(string name, int id, string desc, ItemType type)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemType = type;
		itemIcon = Resources.Load<Sprite> ("" + name);
	}

	public Item()
	{
	}
}
