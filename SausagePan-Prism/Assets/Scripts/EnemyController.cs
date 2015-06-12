using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public string enemyColor;

	private PlayerController playerController;

	public void Start () 
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			bool getsDestroyed = playerController.DamageCheckRGB(enemyColor);

			if(getsDestroyed) 
				Destroy(this.gameObject);
		}
	}
}
