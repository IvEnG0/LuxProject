using UnityEngine;
using System.Collections;

public class SYKA : MonoBehaviour {

	// Use this for initialization

	public GUISkin skin;
	void Start(){
		skin = Resources.Load("sk")as GUISkin;
	}
	void OnGUI()
	{
		GUI.skin = skin;
		if (
		GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width * 0.2f,
		          Screen.height * 0.125f,
		          Screen.width * 0.65f,
		          Screen.height * 0.2f),
			"Level complete!")) 
		{
			Application.LoadLevel ("Levels");
		}

		

		
	}
}
