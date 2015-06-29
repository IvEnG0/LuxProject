using UnityEngine;
using System.Collections;

public class gameOv : MonoBehaviour {
	private GUISkin skin1;
	
	// Use this for initialization
	void Start () {
		skin1 = Resources.Load("newsk")as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player") == null) {
			return;}
		if (GameObject.Find ("Player").gameObject.GetComponent<PlayerHP>().ov==true) 
		{
			//Time.timeScale = 0.0f;
			// AudioListener.pause = true;
			
			
			transform.gameObject.AddComponent<addGameOver>();
			GameObject.Find ("Player").gameObject.GetComponent<PlayerHP>().ov=false;
			//GameObject.Find ("gameov").guiTexture.enabled=true;
			//guiTexture.texture = gameover;
			
			//GameObject.Find ("gameov").guiTexture.enabled=true;
			
			
		} 
		/*else {
Time.timeScale=1.0f;
AudioListener.pause=false;
// Destroy(gameObject.AddComponent<giu1> ());


Component.Destroy(GameObject.Find ("Pause").gameObject.GetComponent<giu1>());
GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused = false;
}*/
		
	}
}
