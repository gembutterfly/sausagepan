using UnityEngine;
using System.Collections;

public class Level6 : MonoBehaviour {
	public GameObject helpLevel6;
	public GameObject mainCamera;

	public GameObject ray_magenta_0;
	public GameObject ray_magenta_1;
	public GameObject ray_magenta_2;
	public GameObject ray_red_0;
	public GameObject ray_red_1;
	public GameObject ray_blue;

	private bool redCloud = false;
	private bool blueCloud = false;

	public void ShowHelpMenu() {
		helpLevel6.SetActive(true);
	}

	public void Start() {
//		GameObject.Find ("blackBuddy").GetComponent<PlayerController>().enabled = false;
//		mainCamera.GetComponent<Animator>().SetTrigger("panCamera");
//		Invoke ("ActivatePlayerController", 6);
	}

	public void ActivatePlayerController() {		
		GameObject.Find ("blackBuddy").GetComponent<PlayerController>().enabled = true;
	}

	public void SetCloud(int cloud, bool value) {
		if (cloud == 1)
			blueCloud = value;
		else
			redCloud = value;

		UpdateRays ();
	}

	public void UpdateRays() {
		if (blueCloud && redCloud) {
			ray_magenta_0.SetActive(false);
			ray_magenta_1.SetActive(true);
			ray_magenta_2.SetActive(false);
			ray_red_0.SetActive(true);
			ray_red_1.SetActive(false);
			ray_blue.SetActive(false);
		}
		if (blueCloud && !redCloud) {
			ray_magenta_0.SetActive(false);
			ray_magenta_1.SetActive(false);
			ray_magenta_2.SetActive(true);
			ray_red_0.SetActive(false);
			ray_red_1.SetActive(false);
			ray_blue.SetActive(true);			
		}
		if (!blueCloud && redCloud) {
			ray_magenta_0.SetActive(false);
			ray_magenta_1.SetActive(true);
			ray_magenta_2.SetActive(false);
			ray_red_0.SetActive(false);
			ray_red_1.SetActive(true);
			ray_blue.SetActive(false);			
		}
		if (!blueCloud && !redCloud) {
			ray_magenta_0.SetActive(true);
			ray_magenta_1.SetActive(false);
			ray_magenta_2.SetActive(false);
			ray_red_0.SetActive(false);
			ray_red_1.SetActive(false);
			ray_blue.SetActive(false);
		}

	}
}
