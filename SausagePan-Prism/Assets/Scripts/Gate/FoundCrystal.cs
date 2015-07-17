using UnityEngine;
using System.Collections;

public class FoundCrystal : MonoBehaviour {

	public int itemID;
	public GameObject gateCrystal;
	public GameObject gateinner;
	public GameObject foundItemMessage;

	private Inventory inventory;
	private Animator animGate;
	private Gate gate;
	private PlayerController playerController;

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			Invoke ("LoadNewLevel", 3);
			foundItemMessage.SetActive(true);
			animGate.enabled = false;
			gateCrystal.SetActive(false);
			gateinner.SetActive(true);
			playerController.CollectingItem();
			playerController.enabled = false;
			inventory.AddItem(itemID);
		}
	}

	// Use this for initialization
	void Start () 
	{
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		animGate = GameObject.Find("Gate").GetComponent<Animator> ();
		gate = GameObject.Find ("Gate").transform.GetChild (0).GetComponent<Gate> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();

		gateinner.SetActive (false);
	}

	void LoadNewLevel()
	{
		gate.NewLevel ();
		foundItemMessage.SetActive (false);
	}
}
