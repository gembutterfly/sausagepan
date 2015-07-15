using UnityEngine;
using System.Collections;

public class QuizzButton : MonoBehaviour {

	public GameManager manager;
	public SwitchLevel level;
	public GameObject violettColorTextures;
	public GameObject violettGreyTextures;
	public GameObject orangeColorTextures;
	public GameObject orangeGreyTextures;
	public Inventory inventory;

	private  SpriteRenderer moth;
	private static bool isClicked = false;
	// Use this for initialization
	void Start () {
		moth = GameObject.Find ("Quiz/moth_show").GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inventory.InventoryContains (2)) {
			orangeGreyTextures.SetActive (false);
			orangeColorTextures.SetActive (true);
		} else {
			orangeGreyTextures.SetActive (true);
			orangeColorTextures.SetActive (false);
		}

		if (inventory.InventoryContains (5)) {
			violettGreyTextures.SetActive (false);
			violettColorTextures.SetActive (true);
		} else {
			violettGreyTextures.SetActive (true);
			violettColorTextures.SetActive (false);
		}

		if (isClicked)
			moth.enabled = false;
		else
			moth.enabled = true;
	}

	void OnMouseDown()
	{
		isClicked = true;
		level.goToLevel ("Quizze");
		//Application.LoadLevel ("Quizze");
	}
}
