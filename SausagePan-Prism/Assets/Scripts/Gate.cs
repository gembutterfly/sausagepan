using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gate : MonoBehaviour {

	GameObject endImg;
	Inventory inventory;
	PlayerController playerController;
	SpriteRenderer playerBody;
	public GameObject endScreen;

	// Use this for initialization
	void Start () 
	{
		endImg = GameObject.FindGameObjectWithTag ("TheEnd");
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		playerBody = GameObject.FindGameObjectWithTag ("Body").GetComponent<SpriteRenderer>();

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
			Debug.Log("Spieler hat Tor betreten");
			Debug.Log ("Seine Farbe ist: ");
			Debug.Log (playerBody.color);
			if( playerBody.color.Equals (Color.blue) ) {
				Debug.Log ("Seine Farbe ist blau");
				Show ();
			}
		}
	}

	void Show()
	{
		endImg.SetActive (true);

//		endImg = GameObject.FindGameObjectWithTag ("TheEnd").GetComponent<AudioSource>();
//		endImg.;

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

	void ShowEndscreen() {
		endScreen.SetActive(true);
		endScreen.transform.Find("EndBackground").gameObject.SetActive(true);
		endScreen.transform.Find("EndText").gameObject.SetActive(true);
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
