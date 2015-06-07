using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	GameObject endImg;
	Inventory inventory;
	PlayerController playerController;

	// Use this for initialization
	void Start () 
	{
		endImg = GameObject.FindGameObjectWithTag ("TheEnd");
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

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
			Show ();
		}
	}

	void Show()
	{
		endImg.SetActive (true);

//		endImg = GameObject.FindGameObjectWithTag ("TheEnd").GetComponent<AudioSource>();
//		endImg.;

		playerController.enabled = false;

		Invoke ("Hide", 2);
		Invoke ("AddItemToInventory", 2);
		Invoke ("PlayerControllerIsAble", 2);
	}
	
	void Hide()
	{
		endImg.SetActive (false);
	}

	void AddItemToInventory()
	{
		inventory.AddItem (0);
	}

	void PlayerControllerIsAble()
	{
		playerController.enabled = true;
	}
}
