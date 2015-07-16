using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public string enemyColor;
	public GameObject enemy;

	private PlayerController playerController;
	private Color trueEnemyColor;

	public void Start () 
	{
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		switch (enemyColor) 
		{
			case "blue": 
				trueEnemyColor = Color.blue; 
				break;
			case "red": 
				trueEnemyColor = Color.red; 
				break;
			case "yellow": 
				trueEnemyColor = new Color(1, 1, 0, 1); 
				break;
			case "green": 
				trueEnemyColor = Color.green; 
				break;
			case "violet": 
				trueEnemyColor = new Color (0.64F, 0, 0.94F, 1); 
				break;
			case "cyan": 
				trueEnemyColor = Color.cyan; 
				break;
			case "orange":
				trueEnemyColor = new Color (1, 0.5F, 0, 1);
				break;
			default: 
				trueEnemyColor = Color.black; 
				break;
		}

		enemy.GetComponent<SpriteRenderer>().color = trueEnemyColor;
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Body")) 
		{
			if (playerController.FindComplementaryColor(trueEnemyColor))
			{
				Destroy(this.gameObject);
			}
		}
	}
}
