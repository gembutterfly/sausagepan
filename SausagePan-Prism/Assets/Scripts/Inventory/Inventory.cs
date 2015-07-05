using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject>();
	public List<Item> Items = new List<Item>();
	public GameObject slots;
	public GameObject toolTip;

	ItemDatabase itemDatabase;
	int x = -400;
	int y = -2;


	public void ShowToolTip(Vector3 toolTipPosition, Item item)
	{
		toolTip.SetActive (true);
		toolTip.GetComponent<RectTransform> ().localPosition = new Vector3 (toolTipPosition.x, toolTipPosition.y + 200, toolTipPosition.z);

		toolTip.transform.GetChild (0).GetComponent<Text> ().text = item.itemName;
		toolTip.transform.GetChild (1).GetComponent<Text> ().text = item.itemDesc;
	}

	public void HideToolTip()
	{
		toolTip.SetActive (false);
	}

	public void AddItem(int id)
	{
		for (int i = 0; i < itemDatabase.items.Count; i++) 
		{
			if(itemDatabase.items[i].itemID == id)
			{
				Item item = itemDatabase.items[i];
				AddItemAtEmptySlot(item);
				
				break;
			}
		}
	}

	// Use this for initialization
	void Start () 
	{
		int slotAmount = 0;
		itemDatabase = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();

		for (int i = 0; i < 7; i++) 
		{
			GameObject slot = (GameObject)Instantiate(slots);
			slot.GetComponent<SlotScript>().slotNumber = slotAmount;
			Slots.Add(slot);
			Items.Add(new Item());
			slot.transform.parent = this.gameObject.transform;
			slot.name = "Slot " + i;
			slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
			slot.GetComponent<RectTransform>().localScale = new Vector3(2,7,0);

			x = x + 130;
			slotAmount++;
		}

//		AddItem (2);
//		AddItem (0);

	}

	void AddItemAtEmptySlot(Item item)
	{
		for (int i = 0; i < Items.Count; i++) 
		{
			if(Items[i].itemName == null)
			{
				Items[i] = item;
				break;
			}
		}
	}

}
