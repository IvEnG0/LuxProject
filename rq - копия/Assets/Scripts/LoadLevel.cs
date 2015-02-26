using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadLevel : MonoBehaviour {

    public string leveName;
    public Slider slider;
    public Text downloading;
    public Text pushButton;
    private AsyncOperation AsOp;
    private float loadingProgress = 0f;
    private int roundLoad;
  
    

	void Start () 
    {
		QualitySettings.SetQualityLevel (3);
		//Убираем панельки навигации и с часами в ведрах 4.4+
		if (Application.platform == RuntimePlatform.Android) {
			using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					obj_Activity.Call ("ActivateImmersiveMode");
				}}}
        AsOp = Application.LoadLevelAsync(leveName);
        AsOp.allowSceneActivation = false;
	}

    void OnGUI()
    {      
        if (loadingProgress > 100)
        {
            pushButton.text = "Tap to play!";
            if (Input.anyKey)
            {
                AsOp.allowSceneActivation = true;//позволить загрузить сцену
            }
        }

        if (loadingProgress <= 100)
        {
            loadingProgress += Time.deltaTime * 25;
            slider.normalizedValue = loadingProgress / 100 ;
            roundLoad = Mathf.RoundToInt(loadingProgress);
            if (AsOp != null && roundLoad <= 100)
            {               
                downloading.text = "Loading : " + roundLoad;
            }
        }       
    }   
}
