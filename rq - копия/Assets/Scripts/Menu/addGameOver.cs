using UnityEngine;
using System.Collections;

public class addGameOver : MonoBehaviour {
	private GUISkin skin1;
	bool paused;
	bool mute1;
	
	void Start(){
		skin1 = Resources.Load("newsk")as GUISkin;
	}
	
	void OnGUI()
	{
		
		GUI.skin = skin1;
		const int buttonWidth = 250;
		const int buttonHeight = 60;
		if (
			GUI.Button(
			// Center in X, 1/3 of the height in Y
			new Rect(Screen.width*0.2f,
		         Screen.height*0.35f,
		         Screen.width*0.65f,
		         Screen.height*0.2f),
			"Restart"
			)
			)
		{
			// Reload the level
			Time.timeScale =1.0f;
			// AudioListener.pause=false;
			Application.LoadLevel("Scene01");
		}
		
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(Screen.width*0.2f,
		         Screen.height*0.575f,
		         Screen.width*0.65f,
		         Screen.height*0.2f),
			"Back to menu"
			)
			)
		{
			
			// Reload the level
			// Time.timeScale =1.0f;
			Destroy(this);
			Application.LoadLevel("Menu");
			// mute1=true;
			
		}
	}
	// Use this for initialization
	
}