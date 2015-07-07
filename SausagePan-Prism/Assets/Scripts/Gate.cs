using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gate : MonoBehaviour {

	public string gateColor;
	public GameObject gateinner;

	private GameManager manager;
	public int levelNumber;

	private Color color;
	private UIManager uIManager;
	private Inventory inventory;
	private SpriteRenderer playerBody;
	private bool finishedLevel = false;
	

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			if(playerBody.color.Equals(color))
			{
				gateinner.SetActive(true);
				finishedLevel = true;
				AddItemToInventory();
			}
		}
	}

	public void LoadNewLevel() 
	{
		//inventory.SaveInventory ();
		StartCoroutine("ChangeLevel");
	}

	// Use this for initialization
	void Start () 
	{
		playerBody = GameObject.FindGameObjectWithTag ("Body").GetComponent<SpriteRenderer>();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

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

		manager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	/**
	 * Add item into inventory and finish level
	 * */
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

	/**
	 * Load level selection
	 * */
	IEnumerator ChangeLevel () 
	{
		float fadeTime = GameObject.Find("UIManager").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);

		manager.setCounter (levelNumber);
		manager.changeLevelValue (levelNumber);

		Application.LoadLevel ("LevelSelection");
//		Application.LoadLevel (Application.loadedLevel - 1);
	}

	void Update()
	{
		if (finishedLevel)
			Invoke ("LoadNewLevel", 2);
	}
}
