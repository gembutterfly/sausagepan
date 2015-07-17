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
		orangeGreyTextures.SetActive (true);
		orangeColorTextures.SetActive (false);

		violettGreyTextures.SetActive (true);
		violettColorTextures.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Item item in inventory.inventory) 
		{
			if (item.itemName != null)
			{
				if(item.itemName.Equals("orange_crystal"))
				{
					orangeGreyTextures.SetActive (false);
					orangeColorTextures.SetActive (true);
				}

				if(item.itemName.Equals ("violet_crystal"))
				{
					violettGreyTextures.SetActive (false);
					violettColorTextures.SetActive (true);
				}
			}
		}
		/*
		if (manager.getHalfQuestionsValue()) {
			orangeGreyTextures.SetActive (false);
			orangeColorTextures.SetActive (true);
		} else {
			orangeGreyTextures.SetActive (true);
			orangeColorTextures.SetActive (false);
		}

		if (manager.getAllQuestionsValue()) {
			violettGreyTextures.SetActive (false);
			violettColorTextures.SetActive (true);
		} else {
			violettGreyTextures.SetActive (true);
			violettColorTextures.SetActive (false);
		}**/

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
