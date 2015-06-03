using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private string playerColor;
	private Color enemyColorRGB;
	private string complementaryColorOfPlayer;
	public string enemyColor;

	private PlayerController playerController;

	public void Start () 
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();

		switch (enemyColor) {
			case "blue": enemyColorRGB    = Color.blue; break;
			case "red": enemyColorRGB     = Color.red; break;
			case "white": enemyColorRGB   = Color.white; break;
			case "yellow": enemyColorRGB  = Color.yellow; break;
			case "green": enemyColorRGB   = Color.green; break;
			case "magenta": enemyColorRGB = Color.magenta; break;
			default: enemyColorRGB        = Color.black; break;
		}
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			GameObject bodypart = GameObject.Find ("blackBuddy/textures/head/head_side");
			SpriteRenderer sprite = bodypart.GetComponent<SpriteRenderer> ();
			
//			DamageCheck(playerColor);
			bool getsDestroyed = playerController.DamageCheckRGB(enemyColorRGB);
			if(getsDestroyed) Destroy(this.gameObject);
		}
	}


//	public void DamageCheck(string playerColor)
//	{
//		complementaryColorOfPlayer = FindComplementaryColorOfPlayer(playerColor);
//		
//		if (complementaryColorOfPlayer.Equals(enemyColor))
//		{
//			Destroy(this.gameObject);
//		} else {
//			playerController.PushBackPlayer();
//			playerController.enabled = false;	
//			Invoke("PlayerControllerIsAble", 2);
//		}
//	}

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

//	public void PlayerControllerIsAble()
//	{
//		playerController.enabled = true;
//	}


}
