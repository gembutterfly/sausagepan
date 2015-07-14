using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<Item> inventory = new List<Item>();
	public int slotX, slotY;
	public GUISkin skin;
	public bool showInventory;

	private ItemDatabase itemDatabase;
	private bool showTooltip;
	private string tooltip;


	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;

	public void AddItem(int id)
	{
		Debug.Log ("AddItem " + id);
		for(int i = 0; i < inventory.Count; i++)
		{
			if(inventory[i].itemName == null)
			{
				if (id < 0)
				{
					inventory[i] = new Item();
					break;
				}

				for(int j = 0; j < itemDatabase.items.Count; j++)
				{
					if(itemDatabase.items[j].itemID == id)
						inventory[i] = itemDatabase.items[j];
				}

				break;
			}
		}
	}

	public void RemoveItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemID == id)
			{
				inventory[i] = new Item();
				break;
			}
		}
	}

	public bool InventoryContains(int id)
	{
		foreach (Item item in inventory)
			if (item.itemID == id)
				return true;
		return false;
	}
	
	public void SaveInventory()
	{
		for(int i = 0; i < inventory.Count; i++)
			PlayerPrefs.SetInt ("Inventory " + i, inventory[i].itemID); 
	}
	
	public void LoadInventory()
	{
		for(int i = 0; i < inventory.Count; i++)
			inventory[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >= 0 ? itemDatabase.items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();
	}

	void Start()
	{
		itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		
		for (int i = 0; i < (slotX * slotY); i++) 
		{
			inventory.Add(new Item());
		}


		AddItem (0);
		AddItem (1);
		AddItem (2);
		AddItem (3);
		AddItem (4);
		AddItem (5);
		AddItem (6);
	}
	
	void Update()
	{
		if (Input.GetButtonDown ("Inventory")) 
		{
			showInventory = !showInventory;
		}
	}
	
	void OnGUI()
	{
//		if (GUI.Button (new Rect (40, 300, 100, 40), "Save"))
//			SaveInventory ();
//		if (GUI.Button (new Rect (40, 350, 100, 40), "Load"))
//			LoadInventory ();
		
		
		tooltip = ""; 
		
		GUI.skin = skin;
		
		if (showInventory) 
		{
			DrawInventory();
			
			if (showTooltip) 
			{
				GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
			}
		}
		
		if (draggingItem) 
		{
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x + 0f, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
			
		}
	}
	
	void  DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		
		for(int y = 0; y < slotY; y++)
		{
			for(int x = 0; x < slotX; x++)
			{
				Rect slotRect = new Rect();
				Item item = inventory[i]; 

				if (Application.loadedLevelName.Equals("Rainbowgame")) 
				{
					int new_x = x + 700 + (y * 45);
					int new_y = 170 + y * 45;

					if (y >= 3)
						new_x = x + 700 + ((y - 6) * (-45));

					slotRect = new Rect(new_x, new_y, 40, 40); 
				}
				else
				{
					slotRect = new Rect(x + 10, 10 + y * 55, 50, 50);
				}

				GUI.Box(slotRect, "");

				if(item.itemName != null)
				{
					if (item.itemIcon != null)
						GUI.DrawTexture(slotRect, inventory[i].itemIcon);
					
					if(slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(inventory[i]);
						//showTooltip = true;
						
						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							prevIndex = i;
							draggedItem = inventory[i];
							inventory[i] = new Item();
						}
						
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				else 
				{
					if (slotRect.Contains(e.mousePosition))
					{
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				
				if(tooltip == "")
				{
					showTooltip = false;
				}
				
				i++;
			}
		}
	}
	
	string CreateTooltip(Item item)
	{
		tooltip = "";
		tooltip += "<color=#000>" + item.itemName + "</color> \n\n" + "<color=#000>" + item.itemDesc + "</color>";
		
		return tooltip;
	}
}