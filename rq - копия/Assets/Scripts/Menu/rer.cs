using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class rer : MonoBehaviour
{
	private GUISkin skin1;
	bool paused;
	public string lev;
	public bool mute1=false;
	void Start(){
		//AudioListener.pause = true;
		enabled = false;
		skin1 = Resources.Load("newsk")as GUISkin;

	}
	void Example()
	{
		if (GameObject.Find ("souund").gameObject.GetComponent<souund> ().mute == true) {
			mute1 = true;
			AudioListener.pause = true;
		} else {
			AudioListener.pause= false;
		}
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
		         Screen.height *0.125f,
		         Screen.width * 0.65f,
		         Screen.height * 0.2f),
			"Resume"
			)
			)
		{
			// Reload the level
		//	paused=false;
			Time.timeScale =1.0f;
			AudioListener.volume=1.0f;
		//	AudioListener.pause=false;
			enabled=false;

			//Destroy(this);
		}
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
		//	Example();
			enabled=false;
			AudioListener.volume=1.0f;
		//	AudioListener.pause=false;
			Application.LoadLevel(lev);
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
			Time.timeScale =1.0f;
			AudioListener.volume=1.0f;
			Destroy(this);
			Application.LoadLevel("Menu");
		//	mute1=true;
			
		}
	}
	
}