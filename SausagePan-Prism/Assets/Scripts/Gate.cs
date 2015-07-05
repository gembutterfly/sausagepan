using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gate : MonoBehaviour {

	public string gateColor;
	public GameObject gateinner; 

	Color color;
	Inventory inventory;
	SpriteRenderer playerBody;
	

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			if(playerBody.color.Equals(color))
			{
				gateinner.SetActive(true);
				//AddItemToInventory();
				StartCoroutine("ChangeLevel");
			}
		}
	}

	// Use this for initialization
	void Start () 
	{
		//inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		playerBody = GameObject.FindGameObjectWithTag ("Body").GetComponent<SpriteRenderer>();

		// Convert gate color(string) to a color
		switch (gateColor) 
		{
			case "blue": 
				color = Color.blue; 
				break;
			case "red": 
				color = Color.red; 
				break;
			case "yellow": 
				color = Color.yellow; 
				break;
			case "green": 
				color = Color.green; 
				break;
			case "magenta": 
				color = Color.magenta;
				break;
			case "cyan": 
				color = Color.cyan; 
				break;
			default: 
				color = Color.black; 
				break;
		}
	}

	/**
	 * Add item into inventory and finish level
	 * */
//	void AddItemToInventory()
//	{
//		switch (gateColor) 
//		{
//			case "blue": 
//				inventory.AddItem (0); 
//				Invoke("ChangeLevel", 2);
//				break;
//			case "red": 
//				inventory.AddItem (1);
//			Invoke("ChangeLevel", 2);
//				break;
//			case "orange": 
//				inventory.AddItem (2); 
//			Invoke("ChangeLevel", 2);
//				break;
//			case "yellow":
//				inventory.AddItem (3);
//			Invoke("ChangeLevel", 2);
//				break;
//			case "green": 
//				inventory.AddItem (4);
//			Invoke("ChangeLevel", 2);
//				break;
//			case "magenta": 
//				inventory.AddItem (5);
//			Invoke("ChangeLevel", 2);
//				break;
//			case "cyan": 
//				inventory.AddItem (6);
//			Invoke("ChangeLevel", 2);
//				break;
//			default: 
//				inventory.AddItem (7);
//			Invoke("ChangeLevel", 2);
//				break;
//		}
//	}

	/**
	 * Load level selection
	 * */
	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("UIManager").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("LevelSelection");
	}

}
