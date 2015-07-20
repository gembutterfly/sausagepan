using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingTitle : MonoBehaviour {

	public Text title;
	public Image background;
	public Image crystal;

	private float duration = 7f;
	private GameObject parent;

	// Update is called once per frame
	void Update () 
	{
		if (Time.time > duration) {
			if (Application.loadedLevelName.Equals("Level6")) {
				GameObject.Find ("UIManager").GetComponent<Level6>().panCamera();
			}
			Destroy (gameObject);
		}

		Color myColor = title.color;
		Color bgColor = background.color;
		Color crystalColor = Color.white;

		float ratio = Time.time / duration;

		myColor.a = Mathf.Lerp (1, 0, ratio);
		bgColor.a = Mathf.Lerp (1, 0, ratio);
		crystalColor.a = Mathf.Lerp (1, 0, ratio);

		title.color = myColor;
		background.color = bgColor;
		crystal.color = crystalColor;
	}
}
