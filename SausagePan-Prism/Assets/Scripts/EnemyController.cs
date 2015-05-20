using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private string playerColor;
	private string complementaryColorOfPlayer;
	private string enemyColor;

	private PlayerController playerController;

	public void Start () 
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();

		enemyColor = "blue";
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			GameObject bodypart = GameObject.Find ("blackBuddy/textures/head/head_side");
			SpriteRenderer sprite = bodypart.GetComponent<SpriteRenderer> ();

			playerColor = "green";
			
			DamageCheck(playerColor);
		}
	}

	public void DamageCheck(string playerColor)
	{
		complementaryColorOfPlayer = FindComplementaryColorOfPlayer(playerColor);
		
		if (complementaryColorOfPlayer.Equals(enemyColor))
		{
			Destroy(this.gameObject);
		} else {
			playerController.PushBackPlayer();
			playerController.enabled = false;	
			Invoke("PlayerControllerIsAble", 2);
		}
	}

	public string FindComplementaryColorOfPlayer(string playerColor)
	{
		switch (playerColor) 
		{
			case "magenta": 
				return "yellow";
			case "blue":
				return "orange";
			case "green":
				return "red";
			case "yellow":
				return "violet";
			case "orange": 
				return "blue";
			case "Red":
				return "green";
			case "cyan":
				return "cyan";
			default:
				return "black";
		}
	}

	public void PlayerControllerIsAble()
	{
		playerController.enabled = true;
	}


}
