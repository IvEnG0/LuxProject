using UnityEngine;
using System.Collections;

public class pauss1 : MonoBehaviour {
	private GUISkin skin1;
	public bool mute1=false;
	//public void snd();
	// Use this for initialization
	void Start () {
		skin1 = Resources.Load("newsk")as GUISkin;
		//GameObject.Find ("Start").gameObject.GetComponent<MenuScript>().enabled=false;

	}

	// Update is called once per frame
	void Update () {
	//	GameObject.Find ("Start").gameObject.GetComponent<MenuScript>().enabled=false;
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (!GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused) 
			{
				Time.timeScale = 0.0f;
		    	//AudioListener.pause = true;
				GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused= true;
				AudioListener.volume=0.0f;
				//transform.gameObject.AddComponent<giu1>();
			 //   GameObject.Find ("Start").gameObject.GetComponent<MenuScript>().enabled=true;
			//	GameObject.Find ("Start").gameObject.GetComponent<GUITexture>().enabled=true;
				GameObject.Find ("resume").gameObject.GetComponent<MenuScript>().enabled=true;
				GameObject.Find ("resume").gameObject.GetComponent<GUITexture>().enabled=true;
				GameObject.Find ("menu").gameObject.GetComponent<MenuScript>().enabled=true;
				GameObject.Find ("menu").gameObject.GetComponent<GUITexture>().enabled=true;
				GameObject.Find ("restart").gameObject.GetComponent<MenuScript>().enabled=true;
				GameObject.Find ("restart").gameObject.GetComponent<GUITexture>().enabled=true;
			} 
			else {
				Time.timeScale=1.0f;
				AudioListener.volume=1.0f;
					//AudioListener.pause=false;

				//	Destroy(gameObject.AddComponent<giu1> ());
				//if(GameObject.Find ("souund").gameObject.GetComponent<souund>().mute==false) {
			//	AudioListener.pause=false;
				//}
				//if(GameObject.Find ("souund").gameObject.GetComponent<souund>().mute==true) {
				//	AudioListener.pause=true;
				//}
			//	AudioListener.pause=false;
				GameObject.Find ("Giu").gameObject.GetComponent<rer>().enabled=false;
				//GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused = false;
				GameObject.Find ("resume").gameObject.GetComponent<MenuScript>().enabled=false;
				GameObject.Find ("resume").gameObject.GetComponent<GUITexture>().enabled=false;
				GameObject.Find ("menu").gameObject.GetComponent<MenuScript>().enabled=false;
				GameObject.Find ("menu").gameObject.GetComponent<GUITexture>().enabled=false;
				GameObject.Find ("restart").gameObject.GetComponent<MenuScript>().enabled=false;
				GameObject.Find ("restart").gameObject.GetComponent<GUITexture>().enabled=false;
				GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused = false;

			}
	}

		}


}