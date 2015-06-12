using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gate : MonoBehaviour {

	public string gateColor;
	public GameObject endImg;

	Color col;
	Inventory inventory;
	PlayerController playerController;
	SpriteRenderer playerBody;
	//public GameObject endScreen;

	// Use this for initialization
	void Start () 
	{
		endImg = GameObject.FindGameObjectWithTag ("TheEnd");
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		playerBody = GameObject.FindGameObjectWithTag ("Body").GetComponent<SpriteRenderer>();

		switch (gateColor) 
		{
			case "blue": 
				col = Color.blue; 
				break;
			case "red": 
				col = Color.red; 
				break;
			case "white": 
				col = Color.white; 
				break;
			case "yellow": 
				col = Color.yellow; 
				break;
			case "green": 
				col = Color.green; 
				break;
			case "magenta": 
				col = Color.magenta;
				break;
			case "cyan": 
				col = Color.cyan; 
				break;
			default: 
				col = Color.black; 
				break;
		}

		Hide ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			if(playerBody.color.Equals(col))
			{
				Debug.Log("Spieler hat Tor betreten" + col);
				Debug.Log ("Seine Farbe ist: " + playerBody.color);

				Show ();
			}
		}
	}

	void Show()
	{
		endImg.SetActive (true);

		playerController.enabled = false;

		Invoke ("Hide", 2);
		Invoke ("ShowEndscreen", 2);
		Invoke ("AddItemToInventory", 2);
		Invoke ("PlayerControllerIsAble", 2);
	}
	
	void Hide()
	{
		endImg.SetActive (false);
	}

//	void ShowEndscreen() {
//		endScreen.SetActive(true);
//		endScreen.transform.Find("EndBackground").gameObject.SetActive(true);
//		endScreen.transform.Find("EndText").gameObject.SetActive(true);
//	}

	void AddItemToInventory()
	{
		switch (gateColor) 
		{
			case "blue": 
				inventory.AddItem (0); 
				break;
			case "red": 
				inventory.AddItem (1);
				break;
			case "orange": 
				inventory.AddItem (2); 
				break;
			case "yellow":
				inventory.AddItem (3);
				break;
			case "green": 
				inventory.AddItem (4);
				break;
			case "magenta": 
				inventory.AddItem (5);
				break;
			case "cyan": 
				inventory.AddItem (6);
				break;
			default: 
				inventory.AddItem (7);
				break;
		}
	}

	void PlayerControllerIsAble()
	{
		playerController.enabled = true;
	}
}
