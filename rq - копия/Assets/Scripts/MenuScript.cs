using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public string LevelToload;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public bool Quitbtn = false;
	public bool Pause = false;

	void Start(){
		QualitySettings.SetQualityLevel (3);
		//Убираем панельки навигации и с часами в ведрах 4.4+
		if (Application.platform == RuntimePlatform.Android) {
			using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					obj_Activity.Call ("ActivateImmersiveMode");
				}}}
	}
	void OnMouseEnter(){
	    
		guiTexture.texture = rollOverTexture;
	}
	void OnMouseExit(){
		guiTexture.texture = normalTexture;
	}
	void OnMouseUp(){
		if(Quitbtn){
			Application.Quit();
		}
		else if(Pause)
		{
			Time.timeScale =1.0f;
			AudioListener.volume=1.0f;
			//	AudioListener.pause=false;
			GameObject.Find ("resume").gameObject.GetComponent<MenuScript>().enabled=false;
			GameObject.Find ("resume").gameObject.GetComponent<GUITexture>().enabled=false;
			GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused= false;
			enabled=false;
		}
		else
		{
			Application.LoadLevel(LevelToload);
			Time.timeScale =1.0f;

		}
		
	}
	// Use this for initialization
	
	
	// Update is called once per frame
	
}
