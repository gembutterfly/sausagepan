using UnityEngine;
using System.Collections;

public class stopaudio_seq1 : MonoBehaviour {
	private int zahl = 300;
	
	void Update(){
		zahl--;
		if (zahl == 0) {
			var go = GameObject.Find ("audio2");
			AudioSource help = go.GetComponent<AudioSource> ();
			help.Stop ();
		}
	}
}
