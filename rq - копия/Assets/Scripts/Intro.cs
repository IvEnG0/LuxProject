using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{ public AudioClip audPoval; 

	
	void Start()
	{//slides[currentSlide].width
		GameObject.Find ("Main Camera").gameObject.GetComponent<AudioSource> ().PlayOneShot(audPoval);

	}

	void Next()
	{
		//GameObject.Find ("Canvas").gameObject.SetActive( true);
			Application.LoadLevel ("Menu");

	}
}