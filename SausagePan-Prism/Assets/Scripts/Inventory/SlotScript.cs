using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

//	public Item item;
//	public int slotNumber;
//
//	Image itemIcon;
//	Inventory inventory;
//
//	// Use this for initialization
//	void Start () 
//	{
//		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
//		itemIcon = gameObject.transform.GetChild (0).GetComponent<Image> ();
//	}
//	
//	// Update is called once per frame
//	void Update () 
//	{
//		if (inventory.Items[slotNumber].itemName != null) 
//		{
//			itemIcon.enabled = true;
//			item = inventory.Items[slotNumber];
//			itemIcon.sprite = inventory.Items[slotNumber].itemIcon;
//		} 
//		else 
//		{
//			itemIcon.enabled = false;
//		}
//	}
//
//	public void OnPointerDown(PointerEventData data)
//	{
//		Debug.Log (transform.name);
//	}
//
//	public void OnPointerEnter(PointerEventData data)
//	{
//		if (inventory.Items [slotNumber].itemName != null) 
//		{
//			inventory.ShowToolTip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
//		}
//	}
//
//	public void OnPointerExit(PointerEventData data)
//	{
//		if (inventory.Items [slotNumber].itemName != null) 
//		{
//			inventory.HideToolTip ();
//		}
//	}
//}
