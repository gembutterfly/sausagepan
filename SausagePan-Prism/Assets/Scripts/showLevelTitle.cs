using UnityEngine;
using System.Collections;

public class showLevelTitle : MonoBehaviour {
	public GameObject board;
	
	private int zahl = 200;
	
	// Update is called once per frame
	void Update () {
		zahl--;
		if(zahl == 0)
		board.SetActive (false);
	}
}
