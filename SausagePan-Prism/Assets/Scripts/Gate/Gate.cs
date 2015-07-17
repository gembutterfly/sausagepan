using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gate : MonoBehaviour {

	public string gateColor;
	public int levelNumber;

	private Animator animGate;
	private GameManager manager;
	private Color color;
	private UIManager uIManager;
	private SpriteRenderer playerBody;


	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			if(playerBody.color.Equals(color))
				animGate.enabled = true;
		}
	}		

	public void NewLevel()
	{
		StartCoroutine ("ChangeLevel");
	}

	// Use this for initialization
	void Start () 
	{
		playerBody = GameObject.FindGameObjectWithTag ("Body").GetComponent<SpriteRenderer>();
		animGate = GameObject.Find("Gate").GetComponent<Animator> ();

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
				color = new Color(1, 1, 0, 1);
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
	 * Load level selection
	 * */
	IEnumerator ChangeLevel () 
	{
		Debug.Log ("ChangeLevel");
		float fadeTime = GameObject.Find("UIManager").GetComponent<Fading>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);

		manager.setCounter (levelNumber);
		manager.changeLevelValue (levelNumber);

		if (levelNumber == 1)
			Application.LoadLevel ("szene1");
		else
			Application.LoadLevel ("LevelSelection");
	}
}
