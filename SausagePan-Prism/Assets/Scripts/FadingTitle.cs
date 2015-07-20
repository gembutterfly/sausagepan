using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingTitle : MonoBehaviour {

	public Text title;
	public Image background;
	public Image crystal;

	private float duration = 7f;
	private GameObject parent;
	private float startTime;
	private float currentTime;

	void Start () {
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () 
	{
		currentTime = Time.time-startTime;
		if (currentTime > duration) {
			if (Application.loadedLevelName.Equals("Level6")) {
				GameObject.Find ("UIManager").GetComponent<Level6>().panCamera();
			}
			Destroy (gameObject);
		}

		Color myColor = title.color;
		Color bgColor = background.color;
		Color crystalColor = Color.white;

		float ratio = currentTime / duration;

		myColor.a = Mathf.Lerp (1, 0, ratio);
		bgColor.a = Mathf.Lerp (1, 0, ratio);
		crystalColor.a = Mathf.Lerp (1, 0, ratio);

		title.color = myColor;
		background.color = bgColor;
		crystal.color = crystalColor;
	}
}
