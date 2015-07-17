using UnityEngine;
using System.Collections;

public class stopaudio_seq2 : MonoBehaviour {
	private int zahl = 200;
	
	void Update(){
		zahl--;
		if (zahl == 0) {
			var go = GameObject.Find ("audio3");
			AudioSource help = go.GetComponent<AudioSource> ();
			help.Stop ();
		}
	}
}
