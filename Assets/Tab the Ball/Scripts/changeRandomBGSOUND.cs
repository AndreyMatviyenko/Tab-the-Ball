using UnityEngine;
using System.Collections;

public class changeRandomBGSOUND : MonoBehaviour {

	public AudioClip[] bgMusics;
	// Use this for initialization
	void Start () {
	
		GetComponent<AudioSource>().clip = bgMusics[Random.Range(0,bgMusics.Length-1)];

		GetComponent<AudioSource>().Play();
	}
	
	 
}
