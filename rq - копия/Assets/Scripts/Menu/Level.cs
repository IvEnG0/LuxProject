using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	void Start()
	{QualitySettings.SetQualityLevel (3);
		//Убираем панельки навигации и с часами в ведрах 4.4+
		if (Application.platform == RuntimePlatform.Android) {
			using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					obj_Activity.Call ("ActivateImmersiveMode");
				}}}}
	public void OnClick(string le){
		Application.LoadLevel(le);
	}
	// Use this for initialization

	
	// Update is called once per frame

}
