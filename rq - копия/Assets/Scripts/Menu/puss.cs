using UnityEngine;
using System.Collections;

public class puss : MonoBehaviour {
	private GUISkin skin1;
	// Use this for initialization
	void Start () {
		skin1 = Resources.Load("newsk")as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (!GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused) 
			{
				Time.timeScale = 0.0f;
				AudioListener.pause = true;
				GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused= true;
				
				transform.gameObject.AddComponent<giu1>();
				
			} 
			else {
				Time.timeScale=1.0f;
				AudioListener.pause=false;
				//	Destroy(gameObject.AddComponent<giu1> ());
				
				
				Component.Destroy(GameObject.Find ("Pause").gameObject.GetComponent<giu1>());
				GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused = false;
			}
	}
}
}