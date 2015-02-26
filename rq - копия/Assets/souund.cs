using UnityEngine;
using System.Collections;

public class souund : MonoBehaviour {
	public bool mute;
	public bool s;
	public GUISkin skin;
	void Start(){
		audio.Play ();
		skin = Resources.Load("newsk")as GUISkin;
	}
	void OnGUI()
	{
		GUI.skin = skin;
		bool sound;
		mute = GUI.Toggle(new Rect(50, 50,100, 100), mute,"");
		if (mute) {
			AudioListener.pause=true;}
		if(!mute)
		{
			AudioListener.pause=false;
		}
	}
	
}