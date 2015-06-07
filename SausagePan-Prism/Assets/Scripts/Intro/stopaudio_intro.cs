using UnityEngine;
using System.Collections;

public class stopaudio_intro : MonoBehaviour {
	private int zahl = 290;
	
	void Update(){
		zahl--;
		if (zahl == 0) {
			var go = GameObject.Find ("audio");
			AudioSource help = go.GetComponent<AudioSource> ();
			help.Stop ();
		}
	}
}
